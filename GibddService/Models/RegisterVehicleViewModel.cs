using System.Collections.Generic;
using DataLayer.Models;

namespace GibddService.Models
{
    public class RegisterVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public IList<Mark> Marks { get; set; }

        public RegisterVehicleViewModel()
        {
            
        }
        public RegisterVehicleViewModel(Vehicle vehicle, IList<Mark> marks)
        {
            Vehicle = vehicle;
            Marks = marks;
        }
    }
}