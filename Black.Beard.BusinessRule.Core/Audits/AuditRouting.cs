using System;
using System.Collections.Generic;

namespace Pssa.BusinessRule.Audits
{
    public class AuditRouting
    {
        public AuditRouting()
        {
            BatchId = Guid.NewGuid();
            ActionSteps = new List<ActionStep>();
        }
        public Guid BatchId { get; }
        public List<ActionStep> ActionSteps { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime EndExecutionDate { get; set; }
        public int ProcessId { get; set; }
    }
}
