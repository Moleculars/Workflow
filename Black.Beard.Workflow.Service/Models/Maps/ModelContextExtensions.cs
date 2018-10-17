using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Bb.Workflow.Service.Models.Maps
{

    /// <summary>
    /// ModelContext Extensions with DataView
    /// </summary>
    public static class ModelContextExtensions
    {

        /// <summary>
        /// Register data in the viewdata
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="controler"></param>
        public static void RegisterForView(this ModelContext ctx, Controller controler)
        {
            var key = ctx.GetType().FullName;
            controler.ViewData.Add(key, ctx);
        }

        /// <summary>
        /// Resolve datas from the viewdatas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T Resolve<T>(this ViewDataDictionary self) where T : ModelContext
        {
            var key = typeof(T).FullName;
            T result =self[key] as T;
            return result;
        }

    }
}
