using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.BusinessRule.Models
{

    public interface IRuleBusinessContext
    {

        /// <summary>
        /// List of event's workflow
        /// </summary>
        List<ResultModel> EventResults { get; }

        ExtendedDataServiceProvider DataServices { get; }

    }

}
