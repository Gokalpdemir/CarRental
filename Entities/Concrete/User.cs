using Castle.Core.Resource;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; }
        public virtual ICollection<Customer> Customers { get; }
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            Customers = new HashSet<Customer>();
        }
    }
}
