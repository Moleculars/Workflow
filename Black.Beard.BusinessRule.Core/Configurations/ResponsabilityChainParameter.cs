namespace Pssa.Routing.Services.Core.Configurations
{

    public class ResponsabilityChainParameter
    {

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public ResponsabilityChainParameter SuccessChain { get; set; }

        public ResponsabilityChainParameter FailChain { get; set; }

        //public string Cdc { get; set; }

        //public string Sfd { get; set; }

    }
}