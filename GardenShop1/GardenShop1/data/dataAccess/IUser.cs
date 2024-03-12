using GardenShop1.data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess
{
    public interface IUser
    {
        bool UpdateUser(User user);
        bool DeleteUser(String username);
        bool AddUser(User user);
        List<User> GetUsers();
        bool FindByUsername(String username);
        User FindById(int idUser);
    }
}
