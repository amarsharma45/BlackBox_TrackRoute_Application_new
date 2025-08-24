using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackRoute_Application.Core.DTO
{
    public class LoadsDetails_dto
    {
		public int LoadId { get;set;}
		public string PickupLocation { get;set;}
		public string DestinationLocation { get; set; }
		public decimal Weight { get;set;}
		public string LoadName { get;set;}
		public string UnitName { get;set;}
		public string Description { get;set;}
		public string CreateBy { get;set;}
		public DateTime CreatedDate { get; set; }
    }
}
