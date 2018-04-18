using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class TemplateController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult CreateTemplate()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTemplate(string templateName,  string html, string folderId = null)
        {
            if(templateName !=null && html != null)
                mailChimpManager.Templates.CreateAsync(templateName, folderId, html);

            return RedirectToAction("GetAllTemplates", "Template");
        }

        public ActionResult UpdateTemplate(string templateId)
        {
            var result = mailChimpManager.Templates.GetAsync(templateId);
            ViewBag.templateId = templateId;

            return View(result.Result);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateTemplate(string templateId, string templateName, string folderId, string html)
        {
            if (templateId != null && templateName != null && html != null)
                mailChimpManager.Templates.UpdateAsync(templateId, templateName, folderId, html);

            return RedirectToAction("GetAllTemplates","Template");
        }

        public ActionResult GetAllTemplates()
        {
            Task<IEnumerable<Template>> result = null;
            result = mailChimpManager.Templates.GetAllAsync();
           
            return View(result.Result.OrderByDescending(x => x.CreatedBy));
        }

        public ActionResult DeleteTemplate(string templateId)
        {
            if (templateId != null)
                mailChimpManager.Templates.DeleteAsync(templateId);

            return RedirectToAction("GetAllTemplates");
        }

        public ActionResult GetTemplate(string templateId)
        {
            Task<Template> result = null;
            if (templateId != null)
              result =   mailChimpManager.Templates.GetAsync(templateId);

            return View(result.Result);
        }

    }
}