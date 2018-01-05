using System.Security.Principal;
using DataLayer.Models.UserRoles;

namespace GibddService.Helpers
{
    public static class PrincipalExtensions
    {
        public static bool IsAdmin(this IPrincipal user)
        {
            return user.IsInRole(nameof(UserRole.Admin));
        }

        public static bool IsGibddStaffOrAdmin(this IPrincipal user)
        {
            return user.IsInRole(nameof(UserRole.GibddStaff)) || user.IsAdmin();
        }

        public static bool IsConfirmedUserOrAdmin(this IPrincipal user)
        {
            return user.IsInRole(nameof(UserRole.ConfirmedUser)) || user.IsAdmin();
        }

        public static bool IsUserOrMore(this IPrincipal user)
        {
            return user.IsInRole(nameof(UserRole.User)) || user.IsConfirmedUserOrAdmin();
        }
    }
}