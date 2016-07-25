using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{

    /// <summary>
    /// Couple of statics method to talk to the model
    /// </summary>

    public class CustomerRepository
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            using (var myDB = new CustomersDb())
            {
                var query = from cust in myDB.Customers
                            select cust;

                return query.ToList();
            }
        }

        public static void InsertCustomer(Customer cust)
        {
            using (var myDB = new CustomersDb())
            {
                myDB.Customers.Add(cust);
                myDB.SaveChanges();
            }
        }
    }
}