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
    public class RouteService : IRouteService
    {
        private readonly IManageRoute _manageRoute;
        public RouteService(IManageRoute manageRoute)
        {
            _manageRoute = manageRoute;
        }

        public void AddUpdateRoute(RouteView_dto routeView_Dto)
        {
            _manageRoute.AddUpdateRoute(routeView_Dto);
        }

        public List<RouteView_dto> GetAllRoutes()
        {
            return _manageRoute.GetAllRoutes();
        }

        public RouteView_dto GetRouteById(int id)
        {
            return _manageRoute.GetRouteById(id);
        }

        public List<DropdwonList_dto> GetLoadListDrp()
        {
            return _manageRoute.GetLoadListDrp();
        }
        public List<DropdwonList_dto> GetRoutListDrp()
        {
            return _manageRoute.GetRoutListDrp();
        }
        public List<DropdwonList_dto> GetTruckListDrp()
        {
            return _manageRoute.GetTruckListDrp();
        }

        public List<GetRoute_Load_MappingData_dto> GetRout_LoadsMapping_Data()
        {
            return _manageRoute.GetRout_LoadsMapping_Data();
        }

        public void AddRoute_LoadMapping(RouteLoadMapping_dto mappingData)
        {
            _manageRoute.AddRoute_LoadMapping(mappingData);
        }
    }
}
