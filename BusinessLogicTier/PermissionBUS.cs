using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class PermissionBUS
    {
        public List<Permission> getListPermission()
        {
            return new PermissionDAO().getListPermission();
        }

        public Permission selectPermissionById(String id)
        {
            return new PermissionDAO().selectPermissionById(id);
        }
    }
}
