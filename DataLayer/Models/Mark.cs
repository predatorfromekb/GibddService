using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}