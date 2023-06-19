using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Models.Requests
{
    public class AddUserInfoRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
