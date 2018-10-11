using System.Text;
using Bb.Workflow;
using Bb.Workflow.Configurations;

namespace Bb.Workflow.Configurations.Rules
{

    /// <summary>
    /// Permet de charger une configuration de regle business par code dans le cadre des tests unitaires
    /// </summary>
    public class RuleConfigBuilderService : AbstractsRuleConfigBuilderService
    {

        private readonly string _configName;
        private readonly StringBuilder _sb;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="config"></param>
        public RuleConfigBuilderService(string configName, string config)
        {
            this._configName = configName;
            this._sb = new StringBuilder(config);
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="sb"></param>
        public RuleConfigBuilderService(string configName, StringBuilder sb)
        {
            this._configName = configName;
            this._sb = sb;
        }

        protected override string GetConfigName()
        {
            return this._configName;
        }

        protected override StringBuilder GetRules()
        {
            return this._sb;
        }

    }

}
