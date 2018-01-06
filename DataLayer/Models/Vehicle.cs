using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Регистрационный номер")]
        public string StateNumber { get; set; }

        [Required]
        [Display(Name = "Заводской номер")]
        public string SerialNumber { get; set; }

        public bool Confirmed { get; set; }
        public string ModelId { get; set; }
        public Model Model { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}