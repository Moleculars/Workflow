using Bb.Core;
using Bb.Workflow.Models;
using Bb.Workflow.Parser;
using Bb.Workflow.Parser.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Workflow.Configurations
{

    public abstract class WorkflowService<TEvent, TContext> 
        where TEvent : ISourceEvent
        where TContext : IWorkflowContext
    {

        public WorkflowService()
        {
            this._readKeys = new Dictionary<string, Func<TEvent, string>>();
            this._firstReadKeys = new Dictionary<string, Func<TEvent, string>>();                    
        }

        public void Register()
        {

            var _workflowConverterVisitor = new StateConverterVisitor<TContext>();

            bool haveWorkflow = false;
            foreach (StringBuilder content in this.GetContents())
            {
                haveWorkflow = true;
                var parser = WorkflowConfigParser.ParseString(content);
                var visitor = new ConfigConverterWorkflowVisitor()
                {
                    Crc = parser.Crc,
                };

                var workflowConfig = (WorkflowDefinitionModel)parser.Visit(visitor);
                workflowConfig.Accept(_workflowConverterVisitor);
                var workflow = new ProcessorWorkflow<TContext>(workflowConfig);

                Register(workflow);

            }

            if (!haveWorkflow)
                throw new Exception($"the service have not workflow assigned");

        }

        protected abstract IEnumerable<StringBuilder> GetContents();

        private Dictionary<string, Storage> _storages = new Dictionary<string, Storage>();

        private class Storage
        {

            public Storage()
            {

            }

            public void Sort(List<KeyValuePair<string, Func<TEvent, string>>> keys, ProcessorWorkflow<TContext> processorWorkflow)
            {

                if (keys.Count == 0)
                    this._item = processorWorkflow;

                else
                {
                    var key = keys[0];
                    keys.RemoveAt(0);
                    this.ReadKey = key.Value;
                    var store = new Storage() { Key = key.Key };
                    _dictionary.Add(store.Key, store);
                    store.Sort(keys, processorWorkflow);
                }

            }

            private Dictionary<string, Storage> _dictionary = new Dictionary<string, Storage>();
            private ProcessorWorkflow<TContext> _item;

            public Func<TEvent, string> ReadKey { get; private set; }
            public string Key { get; set; }

            public ProcessorWorkflow<TContext> Get(TEvent @event, List<string> keys)
            {

                if (ReadKey != null)
                {

                    var key = this.ReadKey(@event);
                    keys.Add(key);

                    if (this._dictionary.TryGetValue(key, out Storage store))
                        return store.Get(@event, keys);

                }

                return this._item;

            }


        }

        private void Register(ProcessorWorkflow<TContext> processorWorkflow)
        {

            var sbMethod = typeof(string).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                    .FirstOrDefault(c => c.Name == "Concat" && !c.IsGenericMethod && c.GetParameters().Length == 2 && c.GetParameters()[0].ParameterType == typeof(string));

            var instance = Expression.Parameter(typeof(TEvent), "instance");

            foreach (List<KeyValuePair<string, string>> matchings in processorWorkflow.Matchings)
            {

                List<KeyValuePair<string, Func<TEvent, string>>> keys = new List<KeyValuePair<string, Func<TEvent, string>>>(matchings.Count);

                foreach (KeyValuePair<string, string> matching in matchings)
                {
                    var k = matching.Key.ToUpper() + "=";
                    if (!this._readKeys.TryGetValue(k, out Func<TEvent, string> fnc))
                    {
                        var constantKey = Expression.Constant(k);
                        var prop = Expression.Property(instance, matching.Key);
                        var call = Expression.Call(null, sbMethod, constantKey, prop);
                        var lambda = Expression.Lambda<Func<TEvent, string>>(call, instance);
                        fnc = lambda.Compile();

                        this._readKeys.Add(k, fnc);

                    }

                    keys.Add(new KeyValuePair<string, Func<TEvent, string>>(string.Concat(matching.Key.ToUpper() + "=", matching.Value), fnc));

                }

                var key = keys[0];
                keys.RemoveAt(0);

                var _k = key.Key.Split('=')[0];
                if (!_firstReadKeys.ContainsKey(_k))
                    _firstReadKeys.Add(_k, key.Value);

                var store = new Storage() { Key = key.Key };
                this._storages.Add(store.Key, store);
                store.Sort(keys, processorWorkflow);

            }

        }

        public ProcessorWorkflow<TContext> GetWorkflow(TEvent @event)
        {

            ProcessorWorkflow<TContext> workflow = null;
            List<string> keys = new List<string>();
            foreach (var item in _firstReadKeys)
            {
                var k = item.Value(@event);
                if (_storages.TryGetValue(k, out Storage store))
                {
                    var wk = store.Get(@event, keys);
                    if (wk != null && workflow != null)
                        throw new Exception("ambigues workflow");
                    workflow = wk;

                }
            }

            if (workflow == null)
                throw new Exception($"no workflow can't be found for event whith key : {string.Join(", ", keys)}");

            return workflow;

        }

        private Dictionary<string, Func<TEvent, string>> _readKeys;
        private Dictionary<string, Func<TEvent, string>> _firstReadKeys;
       
    }

}
