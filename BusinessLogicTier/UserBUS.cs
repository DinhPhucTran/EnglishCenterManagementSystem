using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class UserBUS
    {
        public bool addUser(User user)
        {
            return new UserDAO().addUser(user);
        }
        public bool isExist(String username)
        {
            return new UserDAO().isExist(username);
        }

        public bool checkUser(User user)
        {
            return new UserDAO().checkUser(user);
        }

        public User selectUserByUsername(String name)
        {
            return new UserDAO().selectUserByUsername(name);
        }

        public Permission selectPermissonById(String Id)
        {
            return new UserDAO().selectPermissonById(Id);
        }

        public List<User> getListUser()
        {
            return new UserDAO().getListUser();
        }

        public String getPermissionByUser(User user)
        {
            return new UserDAO().getPermissionByUser(user);
        }

        public bool updatePassword(String username, String pass)
        {
            return new UserDAO().updatePassword(username, pass);
        }

        public bool isConnectionOpen()
        {
            return new UserDAO().isConnectionOpen();
        }

        public void setConnectionString(String conStr)
        {
            
        }
    }
}
