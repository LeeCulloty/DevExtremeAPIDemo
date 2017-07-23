using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebDataLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class ProductController : ApiController
    {


        List<Models.Products.Product> Products = new List<Models.Products.Product>();
        /// <summary>
        /// Gets a list of all products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Products.Product> Get()
        {
            //ensure valid user
            Models.Products products = new Models.Products();
            return products.Get();
        }

        /// <summary>
        /// Gets a single product referenced by the ID parameter.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns></returns>
        public Models.Products.Product Get(int id)
        {
            Models.Products products = new Models.Products();
            return products.Get().FirstOrDefault((p) => p.Id == id);
        }

        /// <summary>
        /// Inserts a new product record in the AKW Product DB.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]Models.Products.Product value)
        {
            Models.Products products = new Models.Products();
            products.Add(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates a product record with product data passed in.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]Models.Products.Product value)
        {
            Models.Products products = new Models.Products();
            products.Update(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes a product record referenced by the ID parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete([FromBody]Models.Products.Product value)
        {
            Models.Products products = new Models.Products();
            products.Delete(value.Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
