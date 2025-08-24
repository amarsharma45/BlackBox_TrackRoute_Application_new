using BlackBox_TrackRoute_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Services.Implementation;
using TrackRoute_Application.Services.Interface;

namespace BlackBox_TrackRoute_Application.Controllers
{
    public class ManageTrucksController : Controller
    {
        private readonly ITruckService _truckService;
        public ManageTrucksController(ITruckService truckService)
        {
            _truckService = truckService;
        }
        [HttpGet]
        public IActionResult TruckDetails()
        {
            List< TruckDetailsViewModel> viewModelList = new List<TruckDetailsViewModel>();
            var Modeldto = _truckService.GetTruckData();
            if (Modeldto != null)
            {
                foreach (var dto in Modeldto)
                {
                    var vm = new TruckDetailsViewModel
                    {
                        TruckId = dto.TruckId,
                        TruckNumber = dto.TruckNumber,
                        Capacity = dto.Capacity,
                        StatusName = dto.StatusName,
                        CreatedBy = dto.CreatedBy,
                        ModelName = dto.ModelName,
                        UnitName = dto.UnitName
                    };
                    viewModelList.Add(vm);
                }
            }

            return View("~/Views/ManageTrucks/TruckDetails.cshtml", viewModelList);
        }
        public IActionResult EditTruck(int id)
        {
            TruckDetailsByIdViewModel viewModel = new TruckDetailsByIdViewModel();
            var dto = _truckService.GetTruckDataById(id);
            if (dto == null)
            {
                return NotFound();
            }
            viewModel = viewModel.MapToViewModel(dto);
            viewModel.btntext = "Update";
      
            return PartialView("~/Views/ManageTrucks/partialViews/_popupPartial.cshtml", viewModel);
        }
        public IActionResult CreateTruck()
        {
            var viewModel = new TruckDetailsByIdViewModel();
            viewModel.btntext = "Submit";
            return PartialView("~/Views/ManageTrucks/partialViews/_popupPartial.cshtml", viewModel);
        }
        [HttpPost]
        public IActionResult AddOrUpdateTruck(TruckDetailsByIdViewModel vm)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            vm.UserId = Convert.ToInt32(userIdClaim.Value);

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            TruckDetailsById_dto dto = new TruckDetailsById_dto
            {
                TruckId = vm.TruckId,
                TruckNumber = vm.TruckNumber,
                ModelName = vm.ModelName,
                Capacity = vm.Capacity,
                UnitId = vm.UnitId,
                StatusId = vm.StatusId,
                UserId = vm.UserId
            };

            _truckService.CreateOrUpdateTruck(dto);

            return Json(new { success = true });
        }

    }


}
