using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Contexts
{
    public class Context<T> : DbContext where T: class
    {
        public Context()
            :base("DefaultConnection")
        { }
        public DbSet<T> Entities { get; set; }
    }
}