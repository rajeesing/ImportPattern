using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.SalesOrder
{
    public class SalesOrderCommand : ICommand
    {
        public async Task Execute(IEnumerable<IModel> model)
        {
            //TODO: Write a logic to insert into the database

        }
    }
}
