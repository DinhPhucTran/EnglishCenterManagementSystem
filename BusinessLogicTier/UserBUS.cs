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
        public bool checkUser(User user)
        {
            return new UserDAO().checkUser(user);
        }
    }
}
