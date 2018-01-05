using System.Data.Entity;

namespace DataLayer
{
    public class Context<T> : DbContext where T: class
    {
        public Context()
            :base("DefaultConnection")
        { }
        public DbSet<T> Entities { get; set; }
    }
}