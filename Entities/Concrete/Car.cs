using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<Rental> Rentals { get;  }
        public virtual ICollection<CarImage> CarImages { get; set; }

        public Car()
        {
            Rentals=new HashSet<Rental>();
            CarImages=new HashSet<CarImage>();
        }
    }
}
