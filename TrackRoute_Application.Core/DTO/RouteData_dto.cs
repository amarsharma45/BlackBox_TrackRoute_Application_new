using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class RouteData_dto
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string Truck { get; set; }
        public string LoadName { get; set; }
        public string LoadPickUpLocation { get; set; }
        public string LoadDestination { get; set; }
        public string LoadWeight { get; set; }
        public string TruckCapacity { get; set; }
    }
}
