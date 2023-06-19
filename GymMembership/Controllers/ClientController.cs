using GymMembership.BLL.Interfaces;
using GymMembership.Models.Models;
using GymMembership.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GymMembership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService authorService)
        {
            _clientService = authorService;
        }

        [HttpGet("GetAllClients")]
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<Client> GetById(Guid id)
        {
            return await _clientService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] AddClientRequest clientRequest)
        {
            await _clientService.Add(clientRequest);
        }

        [HttpPost("Update")]
        public async Task Update([FromBody] UpdateClientRequest request)
        {
            await _clientService.Update(request);
        }

        [HttpDelete("Delete")]
        public void Delete(Guid id)
        {
            _clientService.Delete(id);
        }
    }
}
