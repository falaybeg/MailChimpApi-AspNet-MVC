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
    public class NotesController : Controller
    {
        /// <summary>
        /// NotesController is to add a note for our member 
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();
    
        public ActionResult AddOrUpdateList(string listId, string emailAddressOrHash, string noteId, string note)
        {
            Task<Note> result = null;
            if (listId != null && emailAddressOrHash != null && noteId != null && note != null)
                result = mailChimpManager.Notes.AddOrUpdateAsync(listId, emailAddressOrHash, noteId, note);

            return View(result.Result);
        }

        public ActionResult DeleteList(string listId, string emailAddressOrHash, string noteId, BaseRequest request = null)
        {
            if (listId != null && emailAddressOrHash != null && noteId != null)
                mailChimpManager.Notes.DeleteAsync(listId, emailAddressOrHash, noteId, request);

            return View();
        }

        public ActionResult GetAllNotes(string listId, string emailAddress, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Note>> result = null;

            if (listId != null && emailAddress != null)
                result = mailChimpManager.Notes.GetAllAsync(listId, emailAddress, request);

            return View(result.Result);
        }

        public ActionResult GetNotes(string listId, string emailAddress, string noteId)
        {
            Task<Note> result = null;

            if (listId != null && emailAddress != null && noteId != null)
                result = mailChimpManager.Notes.GetAsync(listId, emailAddress, noteId);

            return View(result.Result);
        }

        public ActionResult GetNoteResponse(string listId, string emailAddressOrHash, QueryableBaseRequest request = null)
        {
            Task<NoteResponse> result = null;

            if (listId != null && emailAddressOrHash != null)
                result = mailChimpManager.Notes.GetResponseAsync(listId, emailAddressOrHash, request);

            return View(result.Result);
        }
    }
}