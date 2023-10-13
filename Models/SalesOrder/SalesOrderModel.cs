using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.SalesOrder
{
    public class SalesOrderModel : IModel
    {
        public int SalesOrderId { get; set; }
        public DateTime SalesOrderDate { get; set; }
    }
}
