using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Models;
using DataLayer.Models.UserRoles;

namespace DataLayer.Repositories
{
    public static class UserInfoRepository
    {
        public static async Task Upsert(UserInfo userInfo)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserInfoes.AddOrUpdate(userInfo);
                await db.SaveChangesAsync();
            }
        }
        public static async Task<UserInfo> FindById(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.UserInfoes
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
        }
        public static async Task<List<UserInfo>> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Users
                    .Where(e => e.Roles
                        .Select(f => f.RoleId)
                        .Contains(((int)UserRole.User).ToString()))
                    .Select(e => e.UserInfo)
                    .Where(e => e.BirthDate != null)
                    .Where(e => e.PassportSeries != null)
                    .Where(e => e.PassportNumber != null)
                    .ToListAsync();
            }
        }
    }
}