using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Models.UserRoles;
using DataLayer.Repositories;
using Microsoft.AspNet.Identity.Owin;

namespace GibddService.Controllers
{
    [Authorize(Roles = nameof(UserRole.GibddStaff))]
    public class GibddStaffController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public GibddStaffController()
        {
        }

        public GibddStaffController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUnconfirmedUsers()
        {
            var userInfos = await UserInfoRepository.Get();
            return View(userInfos);
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmUser(string id)
        { 
            await UserManager.RemoveFromRoleAsync(id, nameof(UserRole.User));
            await UserManager.AddToRoleAsync(id, nameof(UserRole.ConfirmedUser));
            return RedirectToAction("GetUnconfirmedUsers");
        }

        [HttpGet]
        public async Task<ActionResult> GetUnconfirmedVehicles()
        {
            var vehicles = await VehicleRepository.GetUnconfirmedVehicles();
            return View(vehicles);
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmVehicle(int id)
        {
            var vehicle = await VehicleRepository.FindVehicleById(id);
            vehicle.Confirmed = true;
            await VehicleRepository.Upsert(vehicle);
            return RedirectToAction("GetUnconfirmedVehicles");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await VehicleRepository.FindVehicleById(id);
            await VehicleRepository.Delete(vehicle);
            return RedirectToAction("GetUnconfirmedVehicles");
        }
    }
}