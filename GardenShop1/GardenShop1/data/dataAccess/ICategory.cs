using GardenShop1.data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess
{
    public interface ICategory
    {
        List<Category> GetCategories();
        string FindById(int id);
    }
}
