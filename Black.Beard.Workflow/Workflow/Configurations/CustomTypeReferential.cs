using Bb.ComponentModel;
using Black.Beard.Core.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Configurations
{

    public class CustomTypeReferential : ITypeReferential
    {

        public CustomTypeReferential(TypeReferential typeReferential)
        {
            this._instance = typeReferential;
        }

        public void Initialize(VersionedConfigurationDocument configuration)
        {
            this._configuration = configuration;
        }


        private TypeReferential _instance;
        private VersionedConfigurationDocument _configuration;


    }


}
