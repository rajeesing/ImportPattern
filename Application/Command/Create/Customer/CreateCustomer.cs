using ImportPattern.Models.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Application.Command.Create.Customer
{
    public class CreateCustomer:IRequest<int>
    {
        public IEnumerable<CustomerModel> CustomerList { get; set; }
        public CreateCustomer(IEnumerable<CustomerModel> customers)
        {
            CustomerList = customers;
        }
    }
}
