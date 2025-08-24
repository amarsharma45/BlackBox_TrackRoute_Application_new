using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class TruckDetails_dto
    {
        public int TruckId { get; set; }
        public string TruckNumber { get; set; }
        public decimal Capacity { get; set; }
        public string StatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModelName { get; set; }
        public string UnitName { get; set; }
    }
}
