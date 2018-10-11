using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Workflow.Configurations.Rules
{

    public abstract class RuleServiceProviderLoader<TSourceEvent, TContext>
        where TSourceEvent : ISourceEvent
        where TContext : IWorkflowContext
    {


        public RuleServiceProviderLoader()
        {
            this._readKeys = new Dictionary<string, Func<TSourceEvent, string>>();
            this._firstReadKeys = new Dictionary<string, Func<TSourceEvent, string>>();
        }

        public void Register()
        {

            bool haverules = false;
            foreach (StringBuilder content in this.GetContents())
            {
                haverules = true;
                var businessRuleBuilder = new BusinessRuleBuilder<TContext>(new RuleConfigBuilderService(string.Empty, content));
                Register(businessRuleBuilder);
            }

            if (!haverules)
                throw new Exception($"the service have not workflow configuration. please check config (*.rules) in folder '{this.Source}'");

        }

        public abstract string Source { get; }

        private void Register(BusinessRuleBuilder<TContext> ruleBuilder)
        {

            ruleBuilder.GetBusinessRules(); // Pour assigner EventName

            var sbMethod = typeof(string).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                    .FirstOrDefault(c => c.Name == "Concat" && !c.IsGenericMethod && c.GetParameters().Length == 2 && c.GetParameters()[0].ParameterType == typeof(string));

            var instance = Expression.Parameter(typeof(TSourceEvent), "instance");

            

            var _matchings = ruleBuilder.Matchings.ToList();

            foreach (List<KeyValuePair<string, string>> matchings in _matchings)
            {

                matchings.Insert(0, new KeyValuePair<string, string>("Key", ruleBuilder.EventName));

                List<KeyValuePair<string, Func<TSourceEvent, string>>> keys = new List<KeyValuePair<string, Func<TSourceEvent, string>>>(matchings.Count);

                foreach (KeyValuePair<string, string> matching in matchings)
                {
                    var k = matching.Key.ToUpper() + "=";
                    if (!this._readKeys.TryGetValue(k, out Func<TSourceEvent, string> fnc))
                    {
                        var constantKey = Expression.Constant(k);
                        var prop = Expression.Property(instance, matching.Key);
                        var call = Expression.Call(null, sbMethod, constantKey, prop);
                        var lambda = Expression.Lambda<Func<TSourceEvent, string>>(call, instance);
                        fnc = lambda.Compile();

                        this._readKeys.Add(k, fnc);

                    }

                    keys.Add(new KeyValuePair<string, Func<TSourceEvent, string>>(string.Concat(matching.Key.ToUpper() + "=", matching.Value), fnc));

                }

                var key = keys[0];
                keys.RemoveAt(0);

                var _k = key.Key.Split('=')[0];
                if (!_firstReadKeys.ContainsKey(_k))
                    _firstReadKeys.Add(_k, key.Value);

                var store = new Storage() { Key = key.Key };
                this._storages.Add(store.Key, store);
                store.Sort(keys, ruleBuilder);

            }

        }

        public BusinessRuleBuilder<TContext> GetRules(TSourceEvent @event)
        {

            BusinessRuleBuilder<TContext> rules = null;
            List<string> keys = new List<string>();
            foreach (var item in _firstReadKeys)
            {
                var k = item.Value(@event);
                if (_storages.TryGetValue(k, out Storage store))
                {
                    var wk = store.Get(@event, keys);
                    if (wk != null && rules != null)
                        throw new Exception("ambigues rules");
                    rules = wk;

                }
            }

            if (rules == null)
                throw new Exception($"no workflow can't be found for event whith key : {string.Join(", ", keys)}");

            return rules;

        }

        private Dictionary<string, Storage> _storages = new Dictionary<string, Storage>();


        private class Storage
        {

            public Storage()
            {

            }

            public void Sort(List<KeyValuePair<string, Func<TSourceEvent, string>>> keys, BusinessRuleBuilder<TContext> processorWorkflow)
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
            private BusinessRuleBuilder<TContext> _item;

            public Func<TSourceEvent, string> ReadKey { get; private set; }
            public string Key { get; set; }

            public BusinessRuleBuilder<TContext> Get(TSourceEvent @event, List<string> keys)
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

        protected abstract IEnumerable<StringBuilder> GetContents();

        private Dictionary<string, Func<TSourceEvent, string>> _readKeys;
        private Dictionary<string, Func<TSourceEvent, string>> _firstReadKeys;

    }

}