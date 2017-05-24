//Review BA: There are unnecessary usings
using RegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystem.Common.Model
{
    public class AddressModel
    {
        public string City { get; set; }
       
        public string Street { get; set; }

        public int House { get; set; }

        public int? Apartment { get; set; }

        public int? KindergartenId { get; set; }

        // public District? District { get; set; }

       
    }
}
