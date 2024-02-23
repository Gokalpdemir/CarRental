using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color : EntityBase
    {

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public Color()
        {
            Cars = new HashSet<Car>();
        }
    }
}
