using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddBrandDto:IDto
    {
        public String Name { get; set; }

        public AddBrandDto()
        {
            
        }

        public AddBrandDto(string name)
        {
            Name = name;
        }
    }
}
