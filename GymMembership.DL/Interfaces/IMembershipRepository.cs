using GymMembership.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DL.Interfaces
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> GetAll();
        Task<Membership?> GetById(Guid id);
        Task Add(Membership membership);
        Task Delete(Guid id);
        Task Update(Membership membership);
    
    }
}
