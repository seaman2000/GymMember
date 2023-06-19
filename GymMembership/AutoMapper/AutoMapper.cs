using AutoMapper;
using GymMembership.Models.Models;
using GymMembership.Models.Requests;

namespace GymMembership.AutoMapper
{
 
        public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddClientRequest, Client>();
            CreateMap<UpdateClientRequest, Client>();
        }
    }
}
