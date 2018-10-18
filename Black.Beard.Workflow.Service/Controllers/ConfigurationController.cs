using Bb.Workflow.Service.Configurations;
using Bb.Workflow.Service.Models;
using Bb.Workflow.Service.Models.Maps;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bb.Workflow.Service.Controllers
{

    /// <summary>
    /// Append event in the workflow
    /// </summary>
    //[ApiController]
    [Route("[controller]")]
    public class ConfigurationController : Controller
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public ConfigurationController(HostContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Configuration list page
        /// </summary>
        /// <returns></returns>
        [Route("index", Name = "IndexConfigurations")]
        public IActionResult Index(string domain, string version)
        {

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(domain, version),
            }
            .SelectDomainVersion()
            .RegisterForView(this);

            return View();

        }

        #region Domains

        /// <summary>
        /// Adds the domain.
        /// </summary>
        /// <returns></returns>
        [Route("AddDomain", Name = "AddDomain")]
        public IActionResult AddDomain(string selectDomain, string selectVersion, string newDomain)
        {

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(selectDomain, selectVersion),
            }
            .SelectDomainVersion()
            .RegisterForView(this);

            var m = new MdlNameEditor() { SelectedDomain = selectDomain, SelectedVersion = selectVersion, Name = newDomain };

            return View(m);

        }

        /// <summary>
        /// Adds the domain.
        /// </summary>
        /// <returns></returns>
        [Route("CreateDomain", Name = "CreateDomain")]
        public IActionResult AddDomain(MdlNameEditor form)
        {

            form.IsValid = ModelState.IsValid;
            if (!string.IsNullOrEmpty(form.Name) && _context.WorkflowConfiguration.GetDomainConfiguration(form.Name) != null)
            {
                ModelState.AddModelError("Name", $"domain {form.Name} allready exist");
                form.IsValid = false;
            }

            if (!form.IsValid || !_context.WorkflowConfiguration.CreateDomainConfiguration(form.Name))
                return View("AddDomain", form);

            return RedirectToAction("Index", new { domain = form.Name, version = "current" });

        }

        #endregion Domains

        #region Versions

        /// <summary>
        /// Adds the domain.
        /// </summary>
        /// <returns></returns>
        [Route("AddVersion", Name = "AddVersion")]
        public IActionResult AddVersion(string domain, string selectedDomain, string selectedVersion, string newVersion)
        {

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(selectedDomain, selectedVersion),
            }
            .SelectDomainVersion()
            .RegisterForView(this);

            var m = new MdlNameEditor() { SelectedDomain = selectedDomain, SelectedVersion = selectedVersion, Domain = domain, Name = newVersion };

            return View(m);

        }

        /// <summary>
        /// Adds the domain.
        /// </summary>
        /// <returns></returns>
        [Route("CreateVersion", Name = "CreateVersion")]
        public IActionResult AddVersion(MdlNameEditor form)
        {

            IDomainConfiguration _dom = null;
            form.IsValid = ModelState.IsValid;
            if (!string.IsNullOrEmpty(form.Name))
            {
                _dom = _context.WorkflowConfiguration.GetDomainConfiguration(form.Domain);

                if (_dom == null)
                {
                    ModelState.AddModelError("Name", $"domain {form.Name} must exist");
                    form.IsValid = false;
                }
                else
                {
                    if (_dom.GetVersion(form.Name) != null)
                    {
                        ModelState.AddModelError("Name", $"version {form.Name} allready exist in domain {form.Domain}");
                        form.IsValid = false;
                    }
                }

            }

            if (!form.IsValid || _dom == null || !_dom.CreateVersionConfiguration(form.Name))
                return View("AddVersion", form);

            return RedirectToAction("Index", new { domain = form.Domain, version = form.Name });

        }

        #endregion Versions

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <returns></returns>
        [Route("AddFile", Name = "AddFile")]
        public IActionResult AddFile(string domain, string version, string type)
        {

            if (string.IsNullOrEmpty(domain))
                throw new System.Exception($"argument {nameof(domain)} is required");

            if (string.IsNullOrEmpty(version))
                throw new System.Exception($"argument {nameof(version)} is required");

            if (string.IsNullOrEmpty(type))
                throw new System.Exception($"argument {nameof(type)} is required");

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(domain, version),
            }
            .SelectDomainVersion()
            .RegisterForView(this);


            var template = _context
                .WorkflowConfiguration
                .GetTemplateFiles(type)
                .FirstOrDefault()
                ;

            var model = new MdlIncomingFileEditor()
            {
                Domain = domain,
                Version = version,
                Type = type,
                ModelContent = template?.Content ?? "no template",
            };

            return View(model);

        }

        [Route("CreateFile", Name = "CreateFile")]
        public IActionResult AddFile(MdlIncomingFileEditor form)
        {

            if(ModelState.IsValid)
            {

                var _dom = _context.WorkflowConfiguration.GetDomainConfiguration(form.Domain);
                if (_dom == null)
                    ModelState.AddModelError("Domain", $"domain {form.Domain} not found");
                else
                {
                    var _ver = _dom.GetVersion(form.Version);
                    if (_ver == null)
                        ModelState.AddModelError("Version", $"version {form.Version} not found in domain {form.Domain}");

                    else
                    {

                    }

                }

            }

            return View(form);

        }

        private readonly HostContext _context;

    }


}