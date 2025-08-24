using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public int RoleId { get; set; }
        public string RoleName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
