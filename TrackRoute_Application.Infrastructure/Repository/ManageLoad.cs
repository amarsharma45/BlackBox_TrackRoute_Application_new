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
    public class ManageLoad : IManageLoad
    {
        private readonly AppDbContext _context;
        public ManageLoad(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void CreateOrUpdateLoad(LoadsDetailsById_dto loaddetails)
        {
            var loadDetails = _context.Database.ExecuteSqlRaw(
                "EXEC usp_AddOrupdate @LoadId,@PickupLocation,@DestinationLocation,@Weight,@UserId,@LoadName,@UnitId,@Description",
                new SqlParameter("@LoadId", loaddetails.LoadId),
                new SqlParameter("@PickupLocation", loaddetails.PickupLocation),
                new SqlParameter("@DestinationLocation", loaddetails.DestinationLocation),
                new SqlParameter("@Weight", loaddetails.Weight),
                new SqlParameter("@UserId", loaddetails.UserId),
                new SqlParameter("@LoadName", loaddetails.LoadName),
                new SqlParameter("@UnitId", loaddetails.UnitId),
                new SqlParameter("@Description", loaddetails.Description = loaddetails.Description != null ? loaddetails.Description : "")
                );
                
        }

        public List<LoadsDetails_dto> GetLoadData()
        {
          var loadDetails = _context.Database.SqlQueryRaw<LoadsDetails_dto>(
          "EXEC usp_GetLoadDetails").AsEnumerable().ToList();
           return loadDetails;
        }

        public LoadsDetailsById_dto GetLoadDataById(int loadId)
        {
           var loadDetailsbyId = _context.Database.SqlQueryRaw<LoadsDetailsById_dto>(
          "EXEC usp_GetLoadDetailsbyId @LoadId",
          new SqlParameter("@LoadId", loadId)
          ).AsEnumerable().ToList().FirstOrDefault();
           return loadDetailsbyId;
        }
    }
}
