using BlackBox_TrackRoute_Application.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackRoute_Application.Services.Interface;

namespace BlackBox_TrackRoute_Application.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly IUserService _userService;
        public ManageUserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult>  Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _userService.Login(model.Username, model.Password);
            if(user !=null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.FirstName+" "+ user.LastName),
                    new Claim(ClaimTypes.Role,user.RoleName)
                };

                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(Identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

                return RedirectToAction("RouteDetails", "PlanRoute");
            }
            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "ManageUser");
        }
    }
}
