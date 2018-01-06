using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Model
    {
        public int Id { get; set; }
        [Display(Name = "Модель")]
        public string Name { get; set; }

        public int MarkId { get; set; }

        public Mark Mark { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}