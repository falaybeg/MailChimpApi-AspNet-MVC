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
    public class NotesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Note AddOrUpdateList(string listId, string emailAddressOrHash, string noteId, string note)
        {
            Task<Note> result = null;
            if (listId != null && emailAddressOrHash != null && noteId != null && note != null)
                result = mailChimpManager.Notes.AddOrUpdateAsync(listId, emailAddressOrHash, noteId, note);

            return result.Result;
        }

        public void DeleteList(string listId, string emailAddressOrHash, string noteId, BaseRequest request = null)
        {
            if (listId != null && emailAddressOrHash != null && noteId != null)
                mailChimpManager.Notes.DeleteAsync(listId, emailAddressOrHash, noteId, request);
        }

        public IEnumerable<Note> GetAllNotes(string listId, string emailAddress, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Note>> result = null;

            if (listId != null && emailAddress != null)
                result = mailChimpManager.Notes.GetAllAsync(listId,emailAddress,request);

            return result.Result;
        }


        public Note GetNotes(string listId, string emailAddress, string noteId)
        {
            Task<Note> result = null;

            if (listId != null && emailAddress != null && noteId != null)
                result = mailChimpManager.Notes.GetAsync(listId, emailAddress, noteId);

            return result.Result;
        }

        public NoteResponse GetNoteResponse(string listId, string emailAddressOrHash, QueryableBaseRequest request = null)
        {
            Task<NoteResponse> result = null;

            if (listId != null && emailAddressOrHash != null)
                result = mailChimpManager.Notes.GetResponseAsync(listId, emailAddressOrHash, request);

            return result.Result;
        }
    }
}