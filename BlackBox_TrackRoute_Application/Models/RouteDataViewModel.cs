namespace BlackBox_TrackRoute_Application.Models
{
    public class RouteDataViewModel
    {
        public List<DropdwonListViewModel> routelist { get; set; }
        public List<RouteDataModel> routeDataModels  { get; set; }
    }
    public class RouteDataModel
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string Truck { get; set; }
        public string LoadName { get; set; }
        public string LoadPickUpLocation { get; set; }
        public string LoadDestination { get; set; }
        public string LoadWeight { get; set; }
        public string TruckCapacity { get; set; }
    }


}
