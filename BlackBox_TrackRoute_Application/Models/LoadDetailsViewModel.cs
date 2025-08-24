using TrackRoute_Application.Core.DTO;

namespace BlackBox_TrackRoute_Application.Models
{
    public class LoadsDetailsViewModel
    {
        public int LoadId { get; set; }
        public string PickupLocation { get; set; }
        public string DestinationLocation { get; set; }
        public decimal Weight { get; set; }
        public string LoadName { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FormattedCreatedDate => CreatedDate.ToString("dd MMM yyyy");

        public  LoadsDetailsViewModel MapToViewModel(LoadsDetails_dto dto)
        {
            return new LoadsDetailsViewModel
            {
                LoadId = dto.LoadId,
                PickupLocation = dto.PickupLocation,
                DestinationLocation = dto.DestinationLocation,
                Weight = dto.Weight,
                LoadName = dto.LoadName,
                UnitName = dto.UnitName,
                Description = dto.Description,
                CreatedBy = dto.CreateBy,
                CreatedDate = dto.CreatedDate
            };
        }
    }

}
