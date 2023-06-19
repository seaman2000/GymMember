using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Models.Requests
{
    public class AddClientRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }
    }
}
