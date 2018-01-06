using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                    .Include(e => e.Model.Mark)//TODO - в extension
                    .Include(e => e.ApplicationUser)
                    .Where(e => e.ApplicationUserId == userId)
                    .Where(e => e.Confirmed)
                    .ToListAsync();
            }
        }

        public static async Task<Vehicle> FindVehicleById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Vehicles
                    .Include(e => e.Model.Mark)
                    .Include(e => e.ApplicationUser)
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();
            }
        }

        public static async Task<IList<Vehicle>> GetUnconfirmedVehicles()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Vehicles
                    .Include(e => e.Model.Mark)
                    .Include(e => e.ApplicationUser)
                    .Where(e => !e.Confirmed || e.IsWaitForDelete)
                    .ToListAsync();
            }
        }

        public static async Task Upsert(Vehicle vehicle)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Vehicles.AddOrUpdate(vehicle);
                await db.SaveChangesAsync();
            }
        }

        public static async Task Delete(Vehicle vehicle)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Vehicles.Attach(vehicle);
                db.Vehicles.Remove(vehicle);
                await db.SaveChangesAsync();
            }
        }
    }
}