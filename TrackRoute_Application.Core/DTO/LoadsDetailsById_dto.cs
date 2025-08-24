using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class LoadsDetailsById_dto
    {
        public int LoadId { get; set; }
        public string PickupLocation { get; set; }
        public string DestinationLocation { get; set; }
        public decimal Weight { get; set; }
        public string LoadName { get; set; }
        public int UnitId { get; set; }
        public string?Description { get; set; }
        public int  UserId { get; set; }
    }
}
