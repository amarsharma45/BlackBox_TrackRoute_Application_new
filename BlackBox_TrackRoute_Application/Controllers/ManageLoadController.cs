using BlackBox_TrackRoute_Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Services.Interface;

namespace BlackBox_TrackRoute_Application.Controllers
{
    public class ManageLoadController : Controller
    {
        private readonly IManageLoadService  _manageLoadService;
        public ManageLoadController(IManageLoadService manageLoadService)
        {
            _manageLoadService = manageLoadService;
        }
        public IActionResult ManageLoad()
        {
            List<LoadsDetailsViewModel> viewModelList = new List<LoadsDetailsViewModel>();
            var LoadData = _manageLoadService.GetLoadData().ToList(); ;
            if(LoadData !=null)
            {
                foreach(var dto in LoadData)
                {
                    var vm = new LoadsDetailsViewModel
                    {
                        LoadId = dto.LoadId,
                        PickupLocation = dto.PickupLocation,
                        DestinationLocation = dto.DestinationLocation,
                        Weight = dto.Weight,
                        LoadName = dto.LoadName,
                        UnitName = dto.UnitName,
                        Description = dto.Description,
                        CreatedBy = dto.CreateBy,
                        CreatedDate = dto.CreatedDate
                    };
                    viewModelList.Add(vm);
                }
            }
            
            return View("~/Views/ManageLoad/ManageLoad.cshtml", viewModelList);
        }
        public IActionResult EditLoad(int id)
        {
            var dto = _manageLoadService.GetLoadDataById(id);
            var ViewModel = new LoadsDetailsByIdViewModel();
            if (dto !=null)
            {
                ViewModel = ViewModel.MapToViewModel(dto);
                ViewModel.btntext = "Update";
            }
            return PartialView("~/Views/ManageLoad/partialViews/_EditLoadPartial.cshtml", ViewModel);
        }

        public IActionResult CreateLoad()
        {
            var ViewModel = new LoadsDetailsByIdViewModel();
            ViewModel.btntext = "Submit";
            return PartialView("~/Views/ManageLoad/partialViews/_EditLoadPartial.cshtml", ViewModel);
        }

        //[HttpPost]
        public IActionResult AddOrUpdateLoad(LoadsDetailsByIdViewModel vm)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            vm.UserId= Convert.ToInt32(userIdClaim.Value);
            if (!ModelState.IsValid)
            {
                return View(vm); 
            }
            LoadsDetailsById_dto dto = new LoadsDetailsById_dto();
            dto.LoadId = vm.LoadId;
            dto.PickupLocation = vm.PickupLocation;
            dto.DestinationLocation = vm.DestinationLocation;
            dto.Weight = vm.Weight;
            dto.LoadName = vm.LoadName;
            dto.UnitId = vm.UnitId;
            dto.Description = vm.Description;
            dto.UserId = vm.UserId;
            _manageLoadService.CreateOrUpdateLoad(dto);

            return Json(new { success = true });
        }
    }
}
