using GymMembership.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DL.Interfaces
{
    public interface IClientRepository
    {
         
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(Guid id);

        Task Add(Client client);

        Task Delete(Guid id);

        Task Update(Client client);
    }
}

