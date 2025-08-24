using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class RouteLoadMapping_dto
    {
        public int RouteId { get; set; }
        public int TruckId { get; set; }
        public string LoadIds { get; set; } = "";
    }
}
