using AutoMapper;
using GymMembership.BLL.Interfaces;
using GymMembership.DL.Interfaces;
using GymMembership.Models.Models;
using GymMembership.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymMembership.BLL.Services.ClientService;

namespace GymMembership.BLL.Services
{


    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _clientRepository.GetById(id);
        }

        public async Task Add(AddClientRequest clientRequest)
        {
            var client =
                _mapper.Map<Client>(clientRequest);

            client.Id = Guid.NewGuid();

            await _clientRepository.Add(client);
        }

        public async Task Delete(Guid id)
        {
            await _clientRepository.Delete(id);
        }

        public async Task Update(UpdateClientRequest clientRequest)
        {
            var client = _mapper.Map<Client>(clientRequest);

            await _clientRepository.Update(client);
        }

        public Task Add(Client client)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

