using System.ComponentModel.DataAnnotations;
using TrackRoute_Application.Core.DTO;

namespace BlackBox_TrackRoute_Application.Models
{
    public class TruckDetailsByIdViewModel
    {
        public int TruckId { get; set; }

        [Required(ErrorMessage = "Truck Number is required")]
        [StringLength(30, ErrorMessage = "Truck Number cannot exceed 30 characters")]
        public string TruckNumber { get; set; }

        [Required(ErrorMessage = "Model Name is required")]
        [StringLength(30, ErrorMessage = "Model Name cannot exceed 30 characters")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public decimal Capacity { get; set; }

        [Required(ErrorMessage = "Unit ID is required")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Status ID is required")]
        public int StatusId { get; set; }

        public int UserId { get; set; }

        public string btntext { get; set; } = "Submit";

        public TruckDetailsByIdViewModel MapToViewModel(TruckDetailsById_dto dto)
        {
            return new TruckDetailsByIdViewModel
            {
                TruckId = dto.TruckId,
                TruckNumber = dto.TruckNumber,
                ModelName = dto.ModelName,
                Capacity = dto.Capacity,
                UnitId = dto.UnitId,
                StatusId = dto.StatusId,
                UserId = dto.UserId
            };
        }
    }
}
