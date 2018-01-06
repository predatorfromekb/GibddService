using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class UserInfo
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата рождения")]
        public DateTime? BirthDate { get; set; }

        [StringLength(4)]//TODO - добавить валидацию на число
        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }

        [StringLength(6)]
        [Display(Name = "Номер паспорта")]

        public string PassportNumber { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}