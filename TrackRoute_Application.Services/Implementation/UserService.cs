using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Services.Interface;


namespace TrackRoute_Application.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public User Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }
    }
}
