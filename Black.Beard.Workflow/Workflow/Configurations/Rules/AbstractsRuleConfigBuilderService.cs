using Bb.BusinessRule.Models;
using Bb.BusinessRule.Parser;
using Bb.BusinessRule.Parser.Grammar;
using System;
using System.Collections.Generic;

namespace Bb.Workflow.Configurations.Rules
{

    /// <summary>
    /// Provide rule's configurations for evaluate
    /// </summary>
    public abstract class AbstractsRuleConfigBuilderService
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public AbstractsRuleConfigBuilderService()
        {
        }

        /// <summary>
        /// Sign key. this value is the crc32 of the configuration file.
        /// </summary>
        public uint VersionCrc { get; private set; }

        /// <summary>
        /// Return config business rules
        /// </summary>
        /// <returns></returns>
        public RuleRepository GetConfig()
        {

            // Parse rule and build config
            var _converterVisitor = new ConfigConverterRuleBusinessVisitor();
            var rules = GetRules();
            var name = GetConfigName();
            var parser = BusinessRuleConfigParser.ParseString(rules, name);
            var businessRuleConfig = (RuleRepository)parser.Visit(_converterVisitor);
            this.VersionCrc = parser.Crc;
            return businessRuleConfig;
        }

        protected abstract string GetConfigName();

        /// <summary>
        /// Return configuration
        /// </summary>
        /// <returns></returns>
        protected abstract System.Text.StringBuilder GetRules();

    }

}
