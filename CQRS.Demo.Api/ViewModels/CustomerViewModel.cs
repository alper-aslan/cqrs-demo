using CQRS.Demo.Model;

namespace CQRS.Demo.Api.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public Address NewAddress { get; set; }
    }
}