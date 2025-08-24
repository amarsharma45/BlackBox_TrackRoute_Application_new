using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class GetRoute_Load_MappingData_dto
    {
       
        public int RouteId { get; set; } 
        public string RouteName { get; set; } = "";
	    public string LoadName { get; set; } = "";
        public string TruckNumber { get; set; } = "";
        public string ModelName { get; set; } = "";
        public string PickupLocation { get; set; } = "";
	    public string DestinationLocation { get; set; } = "";
        public string RouteDescription { get; set; } = "";
        
    }
}
