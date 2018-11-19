using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using Bb.Workflow.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Bb.Workflow.Configurations;
using Bb.BusinessRule.Models;
using Bb.Workflow.Validators;
using Bb.Core.LocalQueue;
using Bb.Workflow.Parser.Grammar;

namespace Bb.Workflow.Service.Controllers
{

    /// <summary>
    /// Append event in the workflow
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        /// <summary>
        /// Append on the current config
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [Route("{domain}/append")]
        [HttpPut()]
        public IActionResult Append([FromBody][ModelBinder(typeof(SourceEventTracingModelBinder))] SourceEventTracing content)
        {

            var key = content.Key;

            // Chercher dans le dic la listes des configs = qui matches





            return base.Ok();

        }



        /// <summary>
        /// Append on specific config
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="version"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [Route("{domain}/{version}/append")]
        [HttpPut()]
        public IActionResult Append([FromRoute]string domain, [FromRoute]string version, [FromBody][ModelBinder(typeof(SourceEventTracingModelBinder))] SourceEventTracing content)
        {

            return base.Ok();

        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class SourceEventTracingModelBinder : IModelBinder
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {


            var buffer = new MemoryStream();
            var stream = bindingContext.HttpContext.Request.Body;

            MemoryStream msNew = new MemoryStream(16 * 1024);
            stream.CopyTo(msNew);
            StringBuilder sb = null;

            try
            {
                sb = new StringBuilder(Encoding.UTF8.GetString(msNew.ToArray()));
            }
            catch (System.Exception)
            {
                throw new System.Exception("Invalid utf8 encoding");
            }

            var obj = JObject.Parse(sb.ToString());


            SourceEventTracing result = new SourceEventTracing();

            result.Id = obj["id"].Value<string>();
            result.Key = obj["key"].Value<string>();
            result.EventDate = obj["eventDate"].Value<DateTime>();
            result.PostDate = obj["postDate"].Value<DateTime>();
            result.Uid = new Guid(obj["uid"].Value<string>());
            result.Object = obj["object"].Value<JObject>();

            bindingContext.Model = result;

            return Task.CompletedTask;

        }

        //private static void ProcessRequest(ICollection<KeyValuePair<string, object>> context, HttpRequest request)
        //{

        //    //WriteDictionary(context, "web_request:form:", () => request.Form);
        //    //WriteDictionary(context, "web_request:queryString:", () => request.QueryString);

        //    //AddData(context, "web_request:encoding", () => request.ContentEncoding);
        //    //AddData(context, "web_request:contentType", () => request.ContentType);
        //    //AddData(context, "web_request:httpMethod", () => request.HttpMethod);
        //    //AddData(context, "web_request:isAuthenticated", () => request.IsAuthenticated);
        //    //AddData(context, "web_request:url", () => request.Url);


        //    string forwardedFor = string.Empty;

        //    //NameValueCollection headers = TryToGetHeader(() => request.Headers);

        //    //if (headers != null)
        //    //    foreach (var item in headers.AllKeys)
        //    //        switch (item)
        //    //        {

        //    //            case "X-FORWARDED-FOR":
        //    //                forwardedFor = headers["X-FORWARDED-FOR"];
        //    //                break;

        //    //            default:
        //    //                AddData(context, "web_request:" + item, () => headers[item].ToString());
        //    //                break;
        //    //        }


        //    //AddData
        //    //    (
        //    //        context, 
        //    //        "web_request:" + "remote_ip",
        //    //        () => string.IsNullOrEmpty(forwardedFor) ? request.UserHostAddress: forwardedFor
        //    //    );

        //}

        //private static void WriteDictionary(ICollection<KeyValuePair<string, object>> context, string prefixKey, Func<NameValueCollection> datas)
        //{
        //    try
        //    {
        //        var v = datas();

        //        if (v != null)
        //            foreach (var item in v.AllKeys)
        //            {
        //                if (item == "ALL_HTTP" || item == "ALL_RAW")
        //                    continue;

        //                var x = v[item];
        //                if (x != null)
        //                {
        //                    var d = x.ToString();
        //                    if (!string.IsNullOrEmpty(d))
        //                        AddData(context, prefixKey + ":" + item, () => d);
        //                }
        //            }

        //    }
        //    catch
        //    {

        //    }
        //}

    }

}