namespace BlackBox_TrackRoute_Application.Models
{
    public class RouteByIdViewModel
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
        public string CreatedBy { get; set; }
        public string btnText { get; set; } = "Submit";
    }

}
