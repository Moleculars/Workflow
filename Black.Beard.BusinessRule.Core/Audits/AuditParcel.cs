using System;
using System.Collections.Generic;

namespace Pssa.BusinessRule.Audits
{
    public class AuditParcel
    {
        public AuditParcel()
        {
            ChainSteps = new List<ChainStep>();
            AuditDate = DateTime.Now;
        }

        public DateTime AuditDate { get; }

        public Guid BatchId { get; set; }

        //public RoutingQueueItem RoutingQueueItemInitial { get; set; }

        //public RoutingQueueItem RoutingQueueItemFinal { get; set; }

        //public Pudo Pudo { get; set; }

        public List<ChainStep> ChainSteps { get; }

        public string StepName { get; set; }
        public int Order { get; set; }

        public List<object> CarrierServiceRequest { get; set; }
        public object CarrierServiceResponse { get; set; }
    }
}