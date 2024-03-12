using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.model
{
    public class ProcurementItem
    {
        public int IdArticle { get; set; }
        public int IdProcurement { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
