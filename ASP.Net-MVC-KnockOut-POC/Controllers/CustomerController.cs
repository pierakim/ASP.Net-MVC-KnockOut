using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            var cust = CustomerRepository.GetCustomers();
            return cust.ToList();
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            return CustomerRepository.GetCustomers().Where((c) => c.Id == id).FirstOrDefault();
        }

        // POST: api/Customer
        public HttpResponseMessage Post(Customer value)
        {
            CustomerRepository.InsertCustomer(value);
            var response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //// PUT: api/Customer/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Customer/5
        //public void Delete(int id)
        //{
        //}
    }
}
