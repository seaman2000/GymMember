using GymMembership.BLL.Interfaces;
using GymMembership.BLL.Services;
using GymMembership.DL.Interfaces;
using GymMembership.Models.Models;
using Microsoft.VisualBasic;
using Moq;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace GymMembership.Test
{
    public class UnitTest1
    {

        private Mock<IClientService> _clientService;

        private IList<Client> Clients = new List<Client>()
        {
            new Client()
            {
                Id = new Guid("06806dd0-1bc0-42f3-8421-7d7771a94b1d"),
                Age= 22,
                Name = "Svetoslav"
            },
            new Client()
            {
                Id = new Guid("5fee861e-7102-4f14-ab64-f9388b1e4bee"),
                Age= 21,
                Name = "Georgi"
            }
        };

        public UnitTest1()
        {

            _clientService = new Mock<IClientService>();
        }

        [Fact]
        public async Task Age_Check()
        {
        /*    {

                var minAge = 13;
                var expectedAge =
                    Clients.All(x => x.Age > minAge);


                var service = new ClientService(_clientService.Object);


                var result = await service.GetAll(expectedAge);


                Assert.Equal(expectedAge, result);

            } 
        */
        }



    }
}