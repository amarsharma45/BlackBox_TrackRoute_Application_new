using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class RouteView_dto
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
        public string CreatedBy { get; set; }
        public int UserId { get; set; }
    }
}
