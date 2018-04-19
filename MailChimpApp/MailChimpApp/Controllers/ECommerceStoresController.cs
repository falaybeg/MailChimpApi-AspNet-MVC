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
    public class ECommerceStoresController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddECommerceStore(Store store)
        {
            Task<Store> result = null;

            if (store != null)
                result = mailChimpManager.ECommerceStores.AddAsync(store);

            return View(result.Result);
        }

        public ActionResult DeleteStore(string storeId)
        {
            if (storeId != null)
                mailChimpManager.ECommerceStores.DeleteAsync(storeId);

            return View();
        }

        public ActionResult GetAllStores(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Store>> result = null;
            result = mailChimpManager.ECommerceStores.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetList(string storeId, BaseRequest request = null)
        {
            Task<Store> result = null;

            if (storeId != null)
                result = mailChimpManager.ECommerceStores.GetAsync(storeId);

            return View(result.Result);
        }

        public ActionResult GetStoreResponse(QueryableBaseRequest request = null)
        {
            Task<ECommerceResponse> result = null;
            result = mailChimpManager.ECommerceStores.GetResponseAsync(request);

            return View(result.Result);
        }


        public ActionResult GetList(string storeId, Store store)
        {
            Task<Store> result = null;

            if (storeId != null && store != null)
                result = mailChimpManager.ECommerceStores.UpdateAsync(storeId, store);

            return View(result.Result);
        }

        public ActionResult Carts(string storeId)
        {
            IECommerceCartLogic eCommerceCart = null;
            if (storeId != null)
                eCommerceCart = mailChimpManager.ECommerceStores.Carts(storeId);

            return View();
        }

        public ActionResult Customers(string storeId)
        {
            IECommerceCustomerLogic eCommerceCustomer = null;
            if (storeId != null)
                eCommerceCustomer = mailChimpManager.ECommerceStores.Customers(storeId);

            return View();
        }

        public ActionResult Orders(string storeId)
        {
            IECommerceOrderLogic eCommerceCart = null;
            if (storeId != null)
                eCommerceCart = mailChimpManager.ECommerceStores.Orders(storeId);

            return View();
        }

        public ActionResult Products(string storeId)
        {
            IECommerceProductLogic eCommerceCustomer = null;
            if (storeId != null)
                eCommerceCustomer = mailChimpManager.ECommerceStores.Products(storeId);

            return View();
        }

    }
}