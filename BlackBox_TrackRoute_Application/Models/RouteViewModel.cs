using System;
using System.Diagnostics;

namespace BlackBox_TrackRoute_Application.Models
{
    public class RouteViewListsModel
    {
        public List<RouteViewModel> RouteDetailList { get; set; } = new List<RouteViewModel>();
        public List<DropdwonListViewModel> RouteList { get; set; } = new List<DropdwonListViewModel>();
        public List<DropdwonListViewModel> LoadList { get; set; } = new List<DropdwonListViewModel>();
        public List<DropdwonListViewModel> TruckList { get; set; } = new List<DropdwonListViewModel>();
        public List<GetRoute_Load_MappingData_ViewModel> Route_Load_DataMappingList { get; set; } = new List<GetRoute_Load_MappingData_ViewModel>();

        


    }
    public class RouteViewModel
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
        public string CreatedBy { get; set; } = " ";
        public string btnText { get; set; } = "Submit";
    }
}
