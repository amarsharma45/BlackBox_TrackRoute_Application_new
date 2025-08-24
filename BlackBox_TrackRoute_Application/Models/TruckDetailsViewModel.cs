using TrackRoute_Application.Core.DTO;

namespace BlackBox_TrackRoute_Application.Models
{
    public class TruckDetailsViewModel
    {
        public int TruckId { get; set; }
        public string TruckNumber { get; set; }
        public decimal Capacity { get; set; }
        public string StatusName { get; set; }
        public string CreatedBy { get; set; }
        public string ModelName { get; set; }
        public string UnitName { get; set; }

        public TruckDetailsViewModel MapToViewModel(TruckDetails_dto dto)
        {
            return new TruckDetailsViewModel
            {
                TruckId = dto.TruckId,
                TruckNumber = dto.TruckNumber,
                Capacity = dto.Capacity,
                StatusName = dto.StatusName,
                CreatedBy = dto.CreatedBy,
                ModelName = dto.ModelName,
                UnitName = dto.UnitName

            };
        }
    }
     
}
