using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : EntityBase
    {

        public int UserId { get; set; }
        public string CompanyName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }
    }
}
