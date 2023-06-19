using GymMembership.BLL.Interfaces;
using GymMembership.DL.Interfaces;
using GymMembership.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymMembership.BLL.Services.MembershipService;

namespace GymMembership.BLL.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService(IMembershipRepository membershiprepository)
        {

            _membershipRepository = membershiprepository;
        }

        public async Task<IEnumerable<Membership>> GetAll()
        {
            return await _membershipRepository.GetAll();
        }

        public async Task<Membership?> GetById(Guid id)
        {
            var result = await _membershipRepository.GetById(id);

            if (result != null)
            {
                result.TypeofMembership = $"!{result.TypeofMembership}";
            }

            return result;
        }

        public async Task<Membership?> Add(Membership membership)
        {
            membership.Id = Guid.NewGuid();

            var alltypes =
                await _membershipRepository
                    .GetAll();

            var newType =
             alltypes.Any(m => m.TypeofMembership == membership.TypeofMembership);

            if (newType) return null;

            await _membershipRepository.Add(membership);

            return membership;

        }

        public async Task Delete(Guid id)
        {
            await _membershipRepository.Delete(id);
        }

        public async Task Update(Membership membership)
        {
            await _membershipRepository.Update(membership);
        }

        Task IMembershipService.Add(Membership membership)
        {
            throw new NotImplementedException();
        }
    }
}

