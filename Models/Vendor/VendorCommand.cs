using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.Vendor
{
    public class VendorCommand : ICommand
    {
        public async Task Execute(IEnumerable<IModel> model)
        {
            // var vendorModel = (List<VendorModel>)model;
            //TODO: All import operation for vendor
           // return Task.FromResult(0);
        }
    }
}
