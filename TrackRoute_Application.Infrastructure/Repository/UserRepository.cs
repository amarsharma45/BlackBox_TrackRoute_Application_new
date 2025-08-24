using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Infrastructure.Entities;

namespace TrackRoute_Application.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context; 

        public UserRepository(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }
        public User Login(string username, string password)
        {
            var user = _context.Database.SqlQueryRaw<User>(
            "EXEC usp_Login @UserName, @Password",
            new SqlParameter("@UserName", username),
            new SqlParameter("@Password", password)
            ).AsEnumerable().FirstOrDefault();

            return user;
        }
    }
}
