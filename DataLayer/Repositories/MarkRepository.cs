using System.Collections.Generic;
using System.Linq;
using DataLayer.Contexts;
using DataLayer.Models;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public static class MarkRepository
    {
        public static IList<Mark> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Marks.Include(e => e.Models).ToList();
            }
        }

        //public static void Set()
        //{
        //    using (var db = new ApplicationDbContext())
        //    {
        //        var marks = new List<Mark>
        //        {
        //            #region marks                  
        //            new Mark
        //            {
        //                Name = "Audi",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "A3"},
        //                    new Model {Name = "A4"},
        //                    new Model {Name = "A5"},
        //                    new Model {Name = "A6"},
        //                    new Model {Name = "A7"},
        //                    new Model {Name = "Q3"},
        //                    new Model {Name = "Q5"},
        //                    new Model {Name = "Q7"},
        //                    new Model {Name = "R8"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "BMW",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "X1"},
        //                    new Model {Name = "X2"},
        //                    new Model {Name = "X3"},
        //                    new Model {Name = "X4"},
        //                    new Model {Name = "X5"},
        //                    new Model {Name = "X6"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Chevrolet",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "Camaro"},
        //                    new Model {Name = "Corvette"},
        //                    new Model {Name = "Niva"},
        //                    new Model {Name = "Tahoe"},
        //                    new Model {Name = "Traverse"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Ford",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "EcoSport"},
        //                    new Model {Name = "Explorer"},
        //                    new Model {Name = "Fiesta"},
        //                    new Model {Name = "Focus"},
        //                    new Model {Name = "Mondeo"},
        //                    new Model {Name = "Mustang"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Hyundai",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "Creta"},
        //                    new Model {Name = "Elantra"},
        //                    new Model {Name = "H-1"},
        //                    new Model {Name = "Santa Fe"},
        //                    new Model {Name = "Solaris"},
        //                    new Model {Name = "Sonata"},
        //                    new Model {Name = "Tucson"},
        //                    new Model {Name = "i30"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Kia",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "Cerato"},
        //                    new Model {Name = "Mohave"},
        //                    new Model {Name = "Optima"},
        //                    new Model {Name = "Picanto"},
        //                    new Model {Name = "Quoris"},
        //                    new Model {Name = "Rio"},
        //                    new Model {Name = "Sorento"},
        //                    new Model {Name = "Soul"},
        //                    new Model {Name = "Sportage"},
        //                    new Model {Name = "Stinger"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Mazda",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "CX-5"},
        //                    new Model {Name = "CX-9"}
        //                }
        //            },
        //            new Mark
        //            {
        //                Name = "Nissan",
        //                Models = new List<Model>
        //                {
        //                    new Model {Name = "Almera"},
        //                    new Model {Name = "GT-R"},
        //                    new Model {Name = "Juke"},
        //                    new Model {Name = "Murano"},
        //                    new Model {Name = "Qashqai"},
        //                    new Model {Name = "Terrano"},
        //                    new Model {Name = "X-Trail"},
        //                    new Model {Name = "Leaf"}
        //                }
        //            }
        //            #endregion
        //        };

        //        db.Marks.AddRange(marks);
        //        db.SaveChanges();
        //    }
        //}

    }
}