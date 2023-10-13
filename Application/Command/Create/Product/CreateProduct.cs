using ImportPattern.Models.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Application.Command.Create.Product
{
    public class CreateProduct : IRequest<int>
    {
        public IEnumerable<ProductModel> ProductList { get; set; }
        public CreateProduct(IEnumerable<ProductModel> products)
        {
            ProductList = products;
        }
    }
}
