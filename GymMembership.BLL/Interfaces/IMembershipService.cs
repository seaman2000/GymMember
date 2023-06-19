using GymMembership.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.BLL.Interfaces
{
    public interface IMembershipService
    {
        Task<IEnumerable<Membership>> GetAll();
        Task<Membership?> GetById(Guid id);
        Task Add(Membership membership);
        Task Delete(Guid id);
        Task Update(Membership membership);

    }
}
