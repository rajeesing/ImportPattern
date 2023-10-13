using ImportPattern.Application.Command.Create.Product;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImportPattern.Models.Product
{
    public class ProductCommand : ICommand
    {
        Task importProcess = null;
        public IMediator _mediator { get; set; }
        public ProductCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IEnumerable<IModel> model)
        {

            if (model.Count() > 0)
            {
                //foreach (var obj in model)
                {
                    var product = (List<ProductModel>)model;
                    var query = new CreateProduct(product);
                    await _mediator.Send(query);
                }
            }
            //Task.FromResult(0);
        }
    }
}
