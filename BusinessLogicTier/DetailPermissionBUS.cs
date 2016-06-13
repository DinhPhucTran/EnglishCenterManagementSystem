using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class DetailPermissionBUS
    {
        public List<String> getListTabByPermission(String permission)
        {
            return new DetailPermissionDAO().getListTabByPermission(permission);
        }
    }
}
