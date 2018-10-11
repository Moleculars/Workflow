using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.BusinessRule.Models
{

    public class RuleRepository
    {

        public RuleRepository()
        {
            this.Rules = new List<Rule>();
            this.LoadDatas = new List<LoadDataCodeBRExpression>();

            this.Matchings = new List<List<KeyValuePair<string, string>>>();

        }

        public Identifier Name { get; set; }

        public string Comment { get; set; }

        public object MethodLoadDatas { get; set; }
        public List<LoadDataCodeBRExpression> LoadDatas { get; private set; }
        public List<Rule> Rules { get; private set; }

        public List<List<KeyValuePair<string, string>>> Matchings { get; set; }
        public string EventName { get; set; }

        public Expression Accept(IVisitor visitor)
        {
            return visitor.VisitRepository(this);
        }

    }


}
