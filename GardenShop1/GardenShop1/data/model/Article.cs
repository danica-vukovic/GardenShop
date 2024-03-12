using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.model
{
    public class Article
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal ProcurementPrice { get; set; }
        public int Category { get; set; }
        public Boolean isAvailable { get; set; }
    }
}
