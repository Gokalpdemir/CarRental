using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
