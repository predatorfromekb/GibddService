using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Mark
    {
        public int Id { get; set; }
        [Display(Name = "Марка")]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}