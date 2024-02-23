using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Car>? Cars { get; }
        

        public Brand()
        {
            Cars = new HashSet<Car>();
        }
    }
}
