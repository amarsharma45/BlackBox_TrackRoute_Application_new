namespace BlackBox_TrackRoute_Application.Models
{
    public class RouteLoadMapping_ViewModel
    {
        public int RouteId { get; set; }
        public int TruckId { get; set; }
        public List<int> LoadIds { get; set; }
        public int StatusId { get; set; }
    }
}
