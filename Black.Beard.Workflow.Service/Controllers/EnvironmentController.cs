using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;

namespace Bb.Workflow.Service.Controllers
{

    /// <summary>
    /// Provide the of all routes of the site
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {


        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="actionDescriptorCollectionProvider"></param>
        public EnvironmentController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        /// <summary>
        /// return the lst of routes
        /// </summary>
        /// <returns></returns>
        [HttpGet("routes", Name = "ApiEnvironmentGetAllRoutes")]
        public IActionResult GetAllRoutes()
        {

            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["action"],
                Controller = x.RouteValues["controller"],
                Name = x.AttributeRouteInfo?.Name ?? string.Empty,
                Template = x.AttributeRouteInfo?.Template ?? string.Empty
            })
            .ToList();

            return Ok(routes);

        }


    }

}