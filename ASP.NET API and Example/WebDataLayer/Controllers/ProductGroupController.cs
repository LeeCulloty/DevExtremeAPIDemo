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

    public class ProductGroupController : ApiController
    {


        List<Models.ProductGroups.ProductsGroup> ProductGroups = new List<Models.ProductGroups.ProductsGroup>();
        /// <summary>
        /// Gets a list of all product groups.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.ProductGroups.ProductsGroup> Get()
        {
            //ensure valid user
            Models.ProductGroups productgroups = new Models.ProductGroups();
            return productgroups.Get();
        }

        /// <summary>
        /// Gets a single product group refrenced by the ID parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ProductGroups.ProductsGroup Get(int id)
        {
            Models.ProductGroups productgroups = new Models.ProductGroups();
            return productgroups.Get().FirstOrDefault((p) => p.Id == id);
        }

        /// <summary>
        /// Inserts a new product group from the ProductsGroup parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]Models.ProductGroups.ProductsGroup value)
        {
            Models.ProductGroups productgroups = new Models.ProductGroups();
            productgroups.Add(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates a product group record with the matching ProductsGroup parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]Models.ProductGroups.ProductsGroup value)
        {
            Models.ProductGroups productgroups = new Models.ProductGroups();
            productgroups.Update(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes a product group referenced by the ID parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete([FromBody]Models.ProductGroups.ProductsGroup value)
        {
            Models.ProductGroups productgroups = new Models.ProductGroups();
            productgroups.Delete(value.Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
