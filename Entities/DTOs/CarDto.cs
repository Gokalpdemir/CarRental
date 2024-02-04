using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDto:IDto
    {
        public CarDto(int id, int brandId, int colorId, string carName, int modelYear, decimal dailyPrice, string description)
        {
            Id = id;
            BrandId = brandId;
            ColorId = colorId;
            CarName = carName;
            ModelYear = modelYear;
            DailyPrice = dailyPrice;
            Description = description;
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }


    }
}
