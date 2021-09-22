using System.Collections.Generic;
using CQRS.Demo.Model;

namespace CQRS.Demo.BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        void MoveCustomer(int customerId, Address newAddress);
        void ChangeCustomerDebtAmount(int customerId, decimal amount);
        void MakeCustomerPreferred(int customerId);
    }
}
