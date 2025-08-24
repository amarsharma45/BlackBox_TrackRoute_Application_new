using BlackBox_TrackRoute_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Infrastructure.Repository;

namespace BlackBox_TrackRoute_Application.Controllers
{
    public class PlanRouteController : Controller
    {
        private readonly IManageRoute _manageRoute;
        public PlanRouteController(IManageRoute manageRoute)
        {
            _manageRoute = manageRoute;
        }
        public IActionResult RouteDetails()
        {
            var routeViewModel = new RouteViewListsModel();

            // Populate RouteDetailList
            _manageRoute.GetAllRoutes().ForEach(route =>
            {
                routeViewModel.RouteDetailList.Add(new RouteViewModel
                {
                    RouteId = route.RouteId,
                    RouteName = route.RouteName,
                    RouteDescription = route.RouteDescription,
                    CreatedBy = route.CreatedBy
                });
            });

            // Populate LoadList
            _manageRoute.GetLoadListDrp().ForEach(load =>
            {
                routeViewModel.LoadList.Add(new DropdwonListViewModel
                {
                    DrpValue = load.Id,
                    DrpText = load.Name
                });
            });

            // Populate RouteList
            _manageRoute.GetRoutListDrp().ForEach(route =>
            {
                routeViewModel.RouteList.Add(new DropdwonListViewModel
                {
                    DrpValue = route.Id,
                    DrpText = route.Name
                });
            });
            // Populate TruckList
            _manageRoute.GetTruckListDrp().ForEach(route =>
            {
                routeViewModel.TruckList.Add(new DropdwonListViewModel
                {
                    DrpValue = route.Id,
                    DrpText = route.Name
                });
            });

            _manageRoute.GetRout_LoadsMapping_Data().ForEach(route =>
            {
                routeViewModel.Route_Load_DataMappingList.Add(new GetRoute_Load_MappingData_ViewModel
                {
                    RouteName = route.RouteName,
                    LoadName = route.LoadName,
                    TruckNumber=route.TruckNumber,
                    ModelName=route.ModelName,
                    PickupLocation = route.PickupLocation,
                    DestinationLocation = route.DestinationLocation,
                    RouteDescription = route.LoadName
  
                });
            });

            return View(routeViewModel);
        }
        public IActionResult CreateRoute()
        {
            RouteViewModel routeViewModel = new RouteViewModel();

            routeViewModel.btnText = "Submit";
            return PartialView("~/Views/PlanRoute/partialViews/_routePopupPartial.cshtml", routeViewModel);
        }
        public IActionResult EditRoute(int id)
        {
            RouteViewModel routeViewModel = new RouteViewModel();
           var dto = _manageRoute.GetRouteById(id);
            routeViewModel.RouteId = dto.RouteId;
            routeViewModel.RouteName = dto.RouteName;
            routeViewModel.RouteDescription = dto.RouteDescription;
            routeViewModel.CreatedBy = dto.CreatedBy;
            routeViewModel.btnText = "Update";


            return PartialView("~/Views/PlanRoute/partialViews/_routePopupPartial.cshtml", routeViewModel);
        }
        public IActionResult AddUpdateRoute(RouteViewModel vm)
        {
            vm.CreatedBy = "";
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            RouteView_dto dto = new RouteView_dto
            {
                RouteId = vm.RouteId,
                RouteName = vm.RouteName,
                RouteDescription = vm.RouteDescription,
                CreatedBy = vm.CreatedBy,
                UserId = Convert.ToInt32(userIdClaim.Value)
            };
            _manageRoute.AddUpdateRoute(dto);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveMapping([FromBody] RouteLoadMapping_ViewModel model)
        {
            if (model.RouteId == 0 || model.LoadIds == null || !model.LoadIds.Any())
            {
                return Json(new { success = false, message = "Please select a route and at least one load." });
            }
            try
            {
                RouteLoadMapping_dto dto = new RouteLoadMapping_dto
                {
                    RouteId = model.RouteId,
                    TruckId = model.TruckId,
                    LoadIds = string.Join(",", model.LoadIds)
                };
                _manageRoute.AddRoute_LoadMapping(dto);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Failed to save mapping: " + ex.Message });
            }
        }
        
    }
}
