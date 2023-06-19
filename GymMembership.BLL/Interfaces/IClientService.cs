using GymMembership.Models.Models;
using GymMembership.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.BLL.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(Guid id);

        Task Add (AddClientRequest request); 

        Task Delete(Guid id);

        Task Update(UpdateClientRequest request);

    }
}
