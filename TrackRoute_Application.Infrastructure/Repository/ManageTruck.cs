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
    public class ManageTruck : IManageTruck
    {
        private readonly AppDbContext _context;

        public ManageTruck(AppDbContext context)
        {
            _context = context;
        }

        public void CreateOrUpdateTruck(TruckDetailsById_dto truckdetails)
        {
           var truckDetails = _context.Database.ExecuteSqlRaw(
                "EXEC usp_AddOrUpdateTruck @TruckId,@TruckNumber,@ModelName,@Capacity,@UnitId,@StatusId,@UserId",
                new SqlParameter("@TruckId", truckdetails.TruckId),
                new SqlParameter("@TruckNumber", truckdetails.TruckNumber),
                new SqlParameter("@ModelName", truckdetails.ModelName),
                new SqlParameter("@Capacity", truckdetails.Capacity),
                new SqlParameter("@UnitId", truckdetails.UnitId),
                new SqlParameter("@StatusId", truckdetails.StatusId),
                new SqlParameter("@UserId", truckdetails.UserId)
                );
        }

        public List<TruckDetails_dto> GetTruckData()
        {
           var loadDetails = _context.Database.SqlQueryRaw<TruckDetails_dto>(
          "EXEC usp_GetTruckDetails").AsEnumerable().ToList();
           return loadDetails;

        }

        public TruckDetailsById_dto GetTruckDataById(int truckId)
        {
            var loadDetailsbyId = _context.Database.SqlQueryRaw<TruckDetailsById_dto>(
               "EXEC usp_GetTruckDetailsById @LoadId",
               new SqlParameter("@LoadId", truckId)
               ).AsEnumerable().ToList().FirstOrDefault();
            return loadDetailsbyId;
        }
    }
}
