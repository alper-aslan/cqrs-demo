using System;
using CQRS.Demo.Model;

namespace CQRS.Demo.BusinessLogic.Services
{
    public static class FlowerService
    {
        public static void SendFlower(Customer customer)
        {
            Console.WriteLine($"Sending flower to customer: {customer}");
        }
    }
}
