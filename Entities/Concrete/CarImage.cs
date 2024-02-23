using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : EntityBase
    {
     
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public virtual Car Car { get; set; }
    }
}
