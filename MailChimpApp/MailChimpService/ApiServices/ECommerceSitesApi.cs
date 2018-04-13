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
    public class ECommerceSitesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public Store AddECommerceStore(Store store)
        {
            Task<Store> result = null;

            if (store != null)
                result = mailChimpManager.ECommerceStores.AddAsync(store);

            return result.Result;
        }

        public void DeleteStore(string storeId)
        {
            if (storeId != null)
                mailChimpManager.ECommerceStores.DeleteAsync(storeId);
        }

        public IEnumerable<Store> GetAllStores(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Store>> result = null;
            result = mailChimpManager.ECommerceStores.GetAllAsync(request);

            return result.Result;
        }

        public Store GetList(string storeId, BaseRequest request = null)
        {
            Task<Store> result = null;

            if (storeId != null)
                result = mailChimpManager.ECommerceStores.GetAsync(storeId);

            return result.Result;
        }

        public ECommerceResponse GetStoreResponse(QueryableBaseRequest request = null)
        {
            Task<ECommerceResponse> result = null;
            result = mailChimpManager.ECommerceStores.GetResponseAsync(request);

            return result.Result;
        }


        public Store GetList(string storeId, Store store)
        {
            Task<Store> result = null;

            if (storeId != null && store != null)
                result = mailChimpManager.ECommerceStores.UpdateAsync(storeId, store);

            return result.Result;
        }

        public IECommerceCartLogic Carts(string storeId)
        {
            IECommerceCartLogic eCommerceCart = null;
            if (storeId != null)
                eCommerceCart = mailChimpManager.ECommerceStores.Carts(storeId);

            return eCommerceCart;
        }

        public IECommerceCustomerLogic Customers(string storeId)
        {
            IECommerceCustomerLogic eCommerceCustomer = null;
            if (storeId != null)
                eCommerceCustomer = mailChimpManager.ECommerceStores.Customers(storeId);

            return eCommerceCustomer;
        }

        public IECommerceOrderLogic Orders(string storeId)
        {
            IECommerceOrderLogic eCommerceCart = null;
            if (storeId != null)
                eCommerceCart = mailChimpManager.ECommerceStores.Orders(storeId);

            return eCommerceCart;
        }

        public IECommerceProductLogic Products(string storeId)
        {
            IECommerceProductLogic eCommerceCustomer = null;
            if (storeId != null)
                eCommerceCustomer = mailChimpManager.ECommerceStores.Products(storeId);

            return eCommerceCustomer;
        }


    }
}