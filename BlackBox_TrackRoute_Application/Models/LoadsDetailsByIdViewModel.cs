using System.ComponentModel.DataAnnotations;
using TrackRoute_Application.Core.DTO;

namespace BlackBox_TrackRoute_Application.Models
{
    public class LoadsDetailsByIdViewModel
    {
        public int LoadId { get; set; }

        [Required(ErrorMessage = "Pickup Location is required")]
        [StringLength(30, ErrorMessage = "Pickup Location cannot exceed 30 characters")]
        public string PickupLocation { get; set; }

        [Required(ErrorMessage = "Destination Location is required")]
        [StringLength(30, ErrorMessage = "Destination Location cannot exceed 30 characters")]
        public string DestinationLocation { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than zero")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Load Name is required")]
        [StringLength(30, ErrorMessage = "Load Name cannot exceed 30 characters")]
        public string LoadName { get; set; }

        [Required(ErrorMessage = "Unit selection is required")]
        public int UnitId { get; set; }


        public string? Description { get; set; } 

        public string?btntext { get; set; } 
        public int UserId { get; set; }

        public  LoadsDetailsByIdViewModel MapToViewModel(LoadsDetailsById_dto dto)
        {
            return new LoadsDetailsByIdViewModel
            {
                LoadId = dto.LoadId,
                PickupLocation = dto.PickupLocation,
                DestinationLocation = dto.DestinationLocation,
                Weight = dto.Weight,
                LoadName = dto.LoadName,
                UnitId = dto.UnitId,
                Description = dto.Description,
                UserId = dto.UserId


            };
        }
    }

}
