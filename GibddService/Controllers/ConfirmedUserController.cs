using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Models.UserRoles;
using DataLayer.Repositories;
using GibddService.Models;
using Microsoft.AspNet.Identity;

namespace GibddService.Controllers
{
    [Authorize(Roles = nameof(UserRole.ConfirmedUser))]
    public class ConfirmedUserController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetRegisterVehicles()
        {
            var userId = User.Identity.GetUserId();
            var vehicles = await VehicleRepository.GetVehiclesByUserId(userId);
            return View(vehicles);
        }
        [HttpGet]
        public ActionResult RegisterVehicle()
        {
            var userId = User.Identity.GetUserId();
            var vehicle = new Vehicle() {ApplicationUserId = userId};
            var model = new RegisterVehicleViewModel(vehicle, MarkRepository.Get());
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterVehicle(RegisterVehicleViewModel model)
        {
            await VehicleRepository.Insert(model.Vehicle);
            return RedirectToAction("GetRegisterVehicles");
        }
    }
}