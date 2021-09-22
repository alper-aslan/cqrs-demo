using System;
using CQRS.Demo.Model;

namespace CQRS.Demo.BusinessLogic.Services
{
    public static class Billing
    {
        public static void Inform(CustomerAddressChanged customerAddressChanged)
        {
            Console.WriteLine($"Billing: customer address changed: {customerAddressChanged}");
        }

        public static BillingAddress Format(Address address)
        {
            return new BillingAddress();
        }
    }

    public class CustomerAddressChanged
    {
        public string CustomerName { get; set; }
        public BillingAddress NewAddress { get; set; }
        public BillingAddress OldAddress { get; set; }
    }

    public class BillingAddress
    {
    }
}
