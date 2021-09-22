using CQRS.Demo.BusinessLogic;
using CQRS.Demo.BusinessLogic.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICommandHandler<MoveCustomerCommand> moveCustomer;

        public CustomersController(
            ICommandHandler<MoveCustomerCommand> moveCustomer)
        {
            this.moveCustomer = moveCustomer;
        }

        [HttpPost]
        public IActionResult MoveCustomerAddress(MoveCustomerCommand command)
        {
            moveCustomer.Handle(command);
            return NoContent();
        }
    }
}
