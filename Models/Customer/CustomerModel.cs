using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.Customer
{
    public class CustomerModel:IModel
    {
        public int MyProperty { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int AddressType { get; set; }
        public bool IsDefault { get; set; }


    }
}
