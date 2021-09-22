using CQRS.Demo.BusinessLogic.Services;
using CQRS.Demo.BusinessLogic.Services.Mail;
using CQRS.Demo.DataAccess;
using CQRS.Demo.Model;

namespace CQRS.Demo.BusinessLogic.Commands
{
    public class MoveCustomerCommand
    {
        public int CustomerId { get; set; }
        public Address NewAddress { get; set; }
    }

    public class MoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommand>
    {
        public void Handle(MoveCustomerCommand command)
        {
            var repository = new CustomerRepository();
            // Update Database
            var customer = repository.Get(command.CustomerId);
            var oldAddress = customer.Address;
            customer.Address = command.NewAddress;
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
            using var client = new MySmtpClient();
            using var message = new MailMessage();
            message.To = customer.Email;
            message.Subject = "Your address has been changed";
            message.Body = @$"
Dear {customer.Name},

We would like to inform you that we have successfully changed your address in our system.

Cheers.";
            client.Send(message);
        }
    }
}
