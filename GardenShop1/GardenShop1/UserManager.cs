using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenShop1.data.model;

namespace GardenShop1
{
    public class UserManager
    {
        private static UserManager instance;
        private List<User> usersList;

        private UserManager()
        {
            usersList = new List<User>();
        }

        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }

        public List<User> UsersList
            {
                get { return usersList; }
            }
    }
}
