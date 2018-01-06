using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Models.UserRoles;
using DataLayer.Repositories;
using Microsoft.AspNet.Identity;

namespace GibddService.Controllers
{
    [Authorize(Roles = nameof(UserRole.User))]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> ChangeUserInfo()
        {
            var userId = User.Identity.GetUserId();
            var userInfo = await UserInfoRepository.FindById(userId);
            return View(userInfo);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeUserInfo(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                await UserInfoRepository.Upsert(model);
                return RedirectToAction("Index", "Home");
            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            return View(model);
        }
    }
}