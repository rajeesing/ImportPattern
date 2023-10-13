using ImportPattern.Application.Command.Create.Customer;
using ImportPattern.Application.Command.Create.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.Customer
{
    public class CustomerCommand : ICommand
    {
        Task importProcess = null;
        public IMediator _mediator { get; set; }

        public CustomerCommand(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Execute(IEnumerable<IModel> model)
        {
            //if (model.Count() > 0)
            //{
            //    importProcess = new Task(() =>
            //    {
            //        foreach (var obj in model)
            //        {
            //            var customer = (CustomerModel)obj;
            //            //TODO: All import operation for customer
            //        }
            //    }, TaskCreationOptions.LongRunning);
            //    importProcess.Start();

            //}
            //Task.FromResult(0);

            if (model.Count() > 0)
            {
                //foreach (var obj in model)
                {
                    var customers = (List<CustomerModel>)model;
                    var query = new CreateCustomer(customers);
                    await _mediator.Send(query);
                }
            }
            //return Task.CompletedTask;
        }
    }
}
