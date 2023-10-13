using ImportPattern.Models.Product;
using ImportPattern.Persistence.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImportPattern.Application.Command.Create.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        private readonly ProductDbContext _context;
        public CreateProductHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            //Task importProcess = null;
            try
            {
               // importProcess = new Task(() =>
                //{
                    foreach (var obj in request.ProductList)
                    {
                        var entity = new ProductModel
                        {
                            Id = obj.Id,
                            Description = obj.Description,
                            Name = obj.Name,
                            Price = obj.Price,
                            ProductCode = obj.ProductCode

                        };
                        _context.Product.Add(entity);
                        
                    }
                    await _context.SaveChangesAsync(cancellationToken);
                //}, TaskCreationOptions.RunContinuationsAsynchronously);
                //importProcess.Start();

            }
            catch (Exception ex)
            {
                Debug.Assert(true, ex.Message);

            }
            return await Task.FromResult(0);
        }
    }
}
