using System;
using System.Collections.Generic;
using System.Transactions;
using CQRS.Demo.BusinessLogic.Helpers;
using CQRS.Demo.BusinessLogic.Services.Interfaces;
using CQRS.Demo.BusinessLogic.Services.Mail;
using CQRS.Demo.DataAccess;
using CQRS.Demo.Model;

namespace CQRS.Demo.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void MoveCustomer(int customerId, Address newAddress)
        {
            Logger.Log($"Executing MoveCustomer with CustomerId: {customerId}, NewAddress: {newAddress}");

            try
            {
                using (var profiler = new PerformanceProfiler())
                {
                    profiler.StartMeasurement();
                    using (var scope = new TransactionScope())
                    {
                        var repository = new CustomerRepository();
                        // Update Database
                        var customer = repository.Get(customerId);
                        var oldAddress = customer.Address;
                        customer.Address = newAddress;
                        repository.Save(customer);

                        // Inform Billing
                        Billing.Inform(new CustomerAddressChanged
                        {
                            CustomerName = customer.Name,
                            NewAddress = Billing.Format(customer.Address),
                            OldAddress = Billing.Format(oldAddress)
                        });

                        // Send Flower
                        FlowerService.SendFlower(customer);

                        // Send notification mail to customer
                        using (var client = new MySmtpClient())
                        {
                            using (var message = new MailMessage())
                            {
                                message.To = customer.Email;
                                message.Subject = "Your address has been changed";
                                message.Body = @"
Dear customer,

We would like to inform you that we have successfully changed you address in our system.

Cheers.";
                                client.Send(message);
                            }
                        }
                    }
                }

                Logger.Log("MoveCustomer successfully executed");
            }
            catch (Exception ex)
            {
                Logger.Log("MoveCustomer failed.", ex);
                throw;
            }
        }

        public void ChangeCustomerDebtAmount(int customerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void MakeCustomerPreferred(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
