using System.Data.Entity;
using DataLayer.Models;

namespace DataLayer.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}