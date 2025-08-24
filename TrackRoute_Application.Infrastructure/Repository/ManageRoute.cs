using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Infrastructure.Entities;

namespace TrackRoute_Application.Infrastructure.Repository
{
    public class ManageRoute : IManageRoute
    {
        private readonly AppDbContext _context;
        public ManageRoute(AppDbContext context)
        {
            _context = context;
        }

        public void AddUpdateRoute(RouteView_dto route)
        {
            var loadDetails = _context.Database.ExecuteSqlRaw(
               "EXEC usp_AddUpdateRoute @RouteId,@RouteName,@RouteDescription,@UserId",
               new SqlParameter("@RouteId", route.RouteId),
               new SqlParameter("@RouteName", route.RouteName),
               new SqlParameter("@RouteDescription", route.RouteDescription),
               new SqlParameter("@UserId", route.UserId)
               );
        }

        public List<RouteView_dto> GetAllRoutes()
        {
            var routDetails = _context.Database.SqlQueryRaw<RouteView_dto>(
            "EXEC usp_GetRouteDetails").AsEnumerable().ToList();
            return routDetails;
        }
        public RouteView_dto GetRouteById(int routeId)
        {
           var route= _context.Database.SqlQueryRaw<RouteView_dto>(
               "EXEC usp_GetRouteDetailsById @RouteId",
               new Microsoft.Data.SqlClient.SqlParameter("@RouteId", routeId)
               ).AsEnumerable().ToList().FirstOrDefault();
            return route;
        }
        public List<DropdwonList_dto> GetLoadListDrp()
        {
            var routDetails = _context.Database.SqlQueryRaw<DropdwonList_dto>(
            "EXEC usp_GetLoadList").AsEnumerable().ToList();
            return routDetails;
        }
        public List<DropdwonList_dto> GetRoutListDrp()
        {
            var routDetails = _context.Database.SqlQueryRaw<DropdwonList_dto>(
            "EXEC usp_GetRouteList").AsEnumerable().ToList();
            return routDetails;
        }
        public List<DropdwonList_dto> GetTruckListDrp()
        {
            var routDetails = _context.Database.SqlQueryRaw<DropdwonList_dto>(
            "EXEC usp_GetTrucksList").AsEnumerable().ToList();
            return routDetails;
        }

        public List<GetRoute_Load_MappingData_dto> GetRout_LoadsMapping_Data()
        {
            var mappingDetails = _context.Database.SqlQueryRaw<GetRoute_Load_MappingData_dto>(
            "EXEC usp_GetRoute_Load_MappingData").AsEnumerable().ToList();
            return mappingDetails;
        }

        public void AddRoute_LoadMapping(RouteLoadMapping_dto mappingData)
        {
            var loadDetails = _context.Database.ExecuteSqlRaw(
              "EXEC usp_AddRoute_LoadMapping @RouteId,@LoadesId,@TruckId",
              new SqlParameter("@RouteId", mappingData.RouteId),
              new SqlParameter("@LoadesId", mappingData.LoadIds),
              new SqlParameter("@TruckId", mappingData.TruckId)
              );
        }
    }
}
