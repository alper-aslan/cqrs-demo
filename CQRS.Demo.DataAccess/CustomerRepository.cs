using System;
using CQRS.Demo.Model;

namespace CQRS.Demo.DataAccess
{
    public class CustomerRepository
    {
        public Customer Get(int customerId)
        {
            return new Customer
            {
                Id = customerId
            };
        }

        public void Save(Customer customer)
        {
            Console.WriteLine($"Repository: Saved customer {customer}");
        }
    }
}
