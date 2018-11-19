using Bb.Core.Documents;
using Bb.Workflow.Service.Configurations;
using Bb.Workflow.Service.Models;
using Bb.Workflow.Service.Models.Maps;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

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

            return View("SaveFile", model);

        }

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <returns></returns>
        [Route("DeleteFile", Name = "DeleteFile")]
        public IActionResult DeleteFile(string domain, string version, string type, string name)
        {

            if (string.IsNullOrEmpty(domain))
                throw new System.Exception($"argument {nameof(domain)} is required");

            if (string.IsNullOrEmpty(version))
                throw new System.Exception($"argument {nameof(version)} is required");

            if (string.IsNullOrEmpty(type))
                throw new System.Exception($"argument {nameof(type)} is required");

            if (string.IsNullOrEmpty(name))
                throw new System.Exception($"argument {nameof(name)} is required");


            var _dom = _context.WorkflowConfiguration.GetDomainConfiguration(domain);
            if (_dom == null)
                ModelState.AddModelError("Domain", $"domain {domain} not found");
            else
            {
                var _ver = _dom.GetVersion(version);
                if (_ver == null)
                    ModelState.AddModelError("Version", $"version {version} not found in domain {domain}");

                else
                {

                    IConfigurationDocument config = _ver.LoadSubConfigurationDocument(type, name);

                    if (config != null)
                    {
                        if (config.Delete())
                            return RedirectToAction("index");
                        else
                            throw new System.Exception("Failed to delete file.");
                    }

                }

            }

            return RedirectToAction("index");

        }

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <returns></returns>
        [Route("EditFile", Name = "EditFile")]
        public IActionResult EditFile(string domain, string version, string type, string name)
        {

            if (string.IsNullOrEmpty(domain))
                throw new System.Exception($"argument {nameof(domain)} is required");

            if (string.IsNullOrEmpty(version))
                throw new System.Exception($"argument {nameof(version)} is required");

            if (string.IsNullOrEmpty(type))
                throw new System.Exception($"argument {nameof(type)} is required");

            if (string.IsNullOrEmpty(name))
                throw new System.Exception($"argument {nameof(name)} is required");

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(domain, version),
            }
            .SelectDomainVersion()
            .RegisterForView(this);


            var _dom = _context.WorkflowConfiguration.GetDomainConfiguration(domain);
            if (_dom == null)
                ModelState.AddModelError("Domain", $"domain {domain} not found");
            else
            {
                var _ver = _dom.GetVersion(version);
                if (_ver == null)
                    ModelState.AddModelError("Version", $"version {version} not found in domain {domain}");

                else
                {

                    IConfigurationDocument docment = _ver.LoadSubConfigurationDocument(type, name);

                    if (docment != null)
                    {

                        var model = new MdlIncomingFileEditor()
                        {
                            Domain = domain,
                            Version = version,
                            Type = type,
                            Name = name,
                            OldName = name,
                            ModelContent = docment.Content.ToString(),
                        };

                        return View("SaveFile", model);

                    }
                }

            }

            throw new System.Exception("Failed to load model for edit.");

        }

        /// <summary>
        /// save the file.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        [Route("SaveFile", Name = "SaveFile")]
        public IActionResult SaveFile(MdlIncomingFileEditor form)
        {

            if (ModelState.IsValid)
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

                        if (string.IsNullOrEmpty(form.OldName))     // alway empty for creation
                            form.OldName = form.Name;

                        var results = _ver.SaveSubConfigurationDocument(form.Type, form.OldName, new StringBuilder(form.ModelContent));

                        if (form.OldName != form.Name)
                        {
                            var file = _ver.LoadSubConfigurationDocument(form.Type, form.OldName);
                            if (!file.Rename(form.OldName))
                                ModelState.AddModelError("Nmaz", $"Failed to rename the configuration");

                        }

                        foreach (CheckResult check in results)
                            ModelState.AddModelError("ModelContent", check.ToString());

                    }

                }

            }

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(form.Domain, form.Version),
            }
            .SelectDomainVersion()
            .RegisterForView(this);

            form.OldName = form.Name;

            return View(form);

        }

        /// <summary>
        /// Compile the version.
        /// </summary>
        /// <returns></returns>
        [Route("CompileVersion", Name = "CompileVersion")]
        public IActionResult CompileVersion(string domain, string version)
        {

            CompiledConfiguration result = null;

            if (string.IsNullOrEmpty(domain))
                ModelState.AddModelError(nameof(domain), $"argument {nameof(domain)} is required");

            if (string.IsNullOrEmpty(version))
                ModelState.AddModelError(nameof(version), $"argument {nameof(version)} is required");

            var _dom = _context.WorkflowConfiguration.GetDomainConfiguration(domain);
            if (_dom == null)
                ModelState.AddModelError("Domain", $"domain {domain} not found");

            else
            {

                var _ver = _dom.GetVersion(version);

                if (_ver == null)
                    ModelState.AddModelError("Version", $"version {version} not found in domain {domain}");

                else
                {
                    result = _ver.Compile();
                }

            }

            new ConfigurationModelContext()
            {
                ConfigurationList = _context
                    .WorkflowConfiguration
                    .GetDomainConfigurations()
                    .Maps(domain, version),
            }
            .SelectDomainVersion()
            .RegisterForView(this);

            return View(result);

        }


        private readonly HostContext _context;

    }


}