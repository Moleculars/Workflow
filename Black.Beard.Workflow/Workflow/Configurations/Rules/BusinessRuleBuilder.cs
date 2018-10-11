using Bb.BusinessRule.Core.Configurations;
using Bb.BusinessRule.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Workflow.Configurations.Rules
{

    /// <summary>
    /// Provide builder businessRules
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class BusinessRuleBuilder<TContext>
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="ruleConfigBuilderService"></param>
        public BusinessRuleBuilder(AbstractsRuleConfigBuilderService ruleConfigBuilderService)
        {
            this._ruleConfigBuilderService = ruleConfigBuilderService;
            this._config = this._ruleConfigBuilderService.GetConfig();
        }

        public List<List<KeyValuePair<string, string>>> Matchings { get => this._config.Matchings; }

        public string Name { get => this._config.Name.Name; }

        /// <summary>
        /// Sign key. this value is the crc32 of the rule configuration file.
        /// </summary>
        public uint Crc { get => this._ruleConfigBuilderService.VersionCrc; }

        public string EventName { get; private set; }

        public void LoadDatas(TContext context)
        {
            if (this._methodCompiled2 != null)
                this._methodCompiled2(context);
        }

        public Action<TContext, List<ResultModel>> GetBusinessRules()
        {

            if (this._methodCompiled == null)
                lock (_lock)
                    if (this._methodCompiled == null)
                    {

                        var businessRuleConfig = this._ruleConfigBuilderService.GetConfig();
                        this.EventName = businessRuleConfig.EventName;
                        // Match config with method found in assemblies and build rules
                        var visitor = new BuildBusinessRuleVisitor<TContext>();
                        LambdaExpression lambdaExpression = (LambdaExpression)businessRuleConfig.Accept(visitor);
                        this._methodCompiled = lambdaExpression.Compile() as Action<TContext, List<ResultModel>>;
                        this._methodCompiled2 = businessRuleConfig.MethodLoadDatas as Action<TContext>;
                    }

            return this._methodCompiled;

        }

        private volatile object _lock = new object();
        private AbstractsRuleConfigBuilderService _ruleConfigBuilderService;
        private readonly RuleRepository _config;
        private Action<TContext, List<ResultModel>> _methodCompiled;
        private Action<TContext> _methodCompiled2;
    }

}
