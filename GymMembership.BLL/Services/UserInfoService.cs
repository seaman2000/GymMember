using GymMembership.BLL.Interfaces;
using GymMembership.DL.Interfaces;
using GymMembership.Models.Models;
using GymMembership.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.BLL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public Task<UserInfo?> GetUserInfoAsync(string userName, string password)
        {
            return _userInfoRepository.GetUserInfoAsync(userName, password);
        }

        public async Task Add(AddUserInfoRequest user)
        {
            await _userInfoRepository.Add(new UserInfo()
            {
                Id = Guid.NewGuid(),
                Username = user.Email,
                Password = user.Password,
            });
        }

        public Task Add(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }
}
