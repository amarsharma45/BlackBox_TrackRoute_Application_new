namespace BlackBox_TrackRoute_Application.Models
{
    public class GetRoute_Load_MappingData_ViewModel
    {
        public string RouteName { get; set; } = "";
        public string LoadName { get; set; } = "";
        public string TruckNumber { get; set; } = "";
        public string ModelName { get; set; } = "";

        public string PickupLocation { get; set; } = "";
        public string DestinationLocation { get; set; } = "";
        public string RouteDescription { get; set; } = "";
    }
}
