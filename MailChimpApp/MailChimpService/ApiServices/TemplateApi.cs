using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpService.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpService.ApiServices
{
    public class TemplateApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Template CreateTemplate(string templateName, string folderId, string html)
        {
            Task<Template> result = null; 
            
            if(templateName != null && html != null)
            {
               result = mailChimpManager.Templates.CreateAsync(templateName, folderId, html);
            }

            return result.Result;
        }

        public void DeleteTemplate(string templateId)
        {
            if (templateId != null)
                mailChimpManager.Templates.DeleteAsync(templateId);
        }

        public IEnumerable<Template> GetAllTemplates(TemplateRequest request = null)
        {
            Task<IEnumerable<Template>> result = null;
            result = mailChimpManager.Templates.GetAllAsync(request);

            return result.Result;
        }

        public Template GetTemplate(string templateId)
        {
            Task<Template> result = null;

            if(templateId != null)
                result = mailChimpManager.Templates.GetAsync(templateId);

            return result.Result;
        }

        public object GetGTemplateDefaultContent(string templateId, BaseRequest request = null)
        {
            Task<object> result = null;

            if (templateId != null)
                result = mailChimpManager.Templates.GetDefaultContentAsync(templateId, request);

            return result.Result;
        }

        public TemplateResponse GetListResponse(TemplateRequest request = null)
        {
            Task<TemplateResponse> result = null;
            result = mailChimpManager.Templates.GetResponseAsync(request);

            return result.Result;
        }

        public Template UpdateTemplate(string templateId, string templateName ,string folderId, string html)
        {
            Task<Template> result = null;

            if (templateId != null && templateName != null && folderId != null && html != null)
                mailChimpManager.Templates.UpdateAsync(templateId, templateName, folderId, html);

            return result.Result;
        }

    }
}