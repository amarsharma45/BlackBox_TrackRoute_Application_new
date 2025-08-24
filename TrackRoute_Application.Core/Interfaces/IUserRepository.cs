using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;

namespace TrackRoute_Application.Core.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password);
    }
}
