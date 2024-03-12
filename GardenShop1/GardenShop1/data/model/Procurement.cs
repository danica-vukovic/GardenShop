using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.model
{
    public class Procurement
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int IdUser { get; set; }
        public int IdProcurer { get; set; } 
    }
}
