using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public static class VehicleRepository
    {
        public static async Task<List<Vehicle>> GetVehiclesByUserId(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Vehicles
                    .Include("Model")
                    .Include("ApplicationUser")
                    .Where(e => e.ApplicationUserId == userId)
                    .Where(e => e.Confirmed)
                    .ToListAsync();
            }
        }

        public static async Task Insert(Vehicle vehicle)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
            }
        }
    }
}