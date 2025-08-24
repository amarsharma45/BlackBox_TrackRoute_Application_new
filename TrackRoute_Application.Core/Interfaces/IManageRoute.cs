using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;

namespace TrackRoute_Application.Core.Interfaces
{
    public interface IManageRoute
    {
        public List<RouteView_dto> GetAllRoutes();
        public void AddUpdateRoute(RouteView_dto route);
        public RouteView_dto GetRouteById(int routeId);

        public List<DropdwonList_dto> GetRoutListDrp();
        public List<DropdwonList_dto> GetLoadListDrp();
        public List<DropdwonList_dto> GetTruckListDrp();

        public List<GetRoute_Load_MappingData_dto> GetRout_LoadsMapping_Data();
        public void AddRoute_LoadMapping(RouteLoadMapping_dto mappingData);
    }
}
