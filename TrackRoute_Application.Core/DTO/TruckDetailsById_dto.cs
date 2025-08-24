using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public  class TruckDetailsById_dto
    {
        public int TruckId { get; set; }

        public string TruckNumber { get; set; }

        public string ModelName { get; set; }

        public decimal Capacity { get; set; }

        public int UnitId { get; set; }

        public int StatusId { get; set; }

        public int UserId { get; set; }
    }
}
