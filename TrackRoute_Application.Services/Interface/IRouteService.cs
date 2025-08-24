using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;

namespace TrackRoute_Application.Services.Interface
{
    public interface IRouteService
    {
        public List<RouteView_dto> GetAllRoutes();
        public RouteView_dto GetRouteById(int routeId);
        public void AddUpdateRoute(RouteView_dto routeView_Dto);

        public List<DropdwonList_dto> GetRoutListDrp();
        public List<DropdwonList_dto> GetLoadListDrp();
        public List<DropdwonList_dto> GetTruckListDrp();

        public List<GetRoute_Load_MappingData_dto> GetRout_LoadsMapping_Data();
        public void AddRoute_LoadMapping(RouteLoadMapping_dto mappingData);
        public List<RouteData_dto> GetDetailedRouteData();
    }
}
