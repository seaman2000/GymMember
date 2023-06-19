using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Models.Models
{
    public class Membership
    {
        public Guid Id { get; set; }

        public string TypeofMembership { get; set; }

        public int Price { get; set; }

        public string Period { get; set; }    
    }
}
