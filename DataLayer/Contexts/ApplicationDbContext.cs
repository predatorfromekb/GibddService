using System.Data.Entity;
using DataLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {}
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}