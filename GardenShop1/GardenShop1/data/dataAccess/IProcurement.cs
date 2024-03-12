using GardenShop1.data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess
{
    public interface IProcurement
    {
        int AddProcurement(Procurement procurement);
        List<Procurement> GetProcurements(int idUser);
    }
}
