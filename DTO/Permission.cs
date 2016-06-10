using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Permission
    {
        String mIdPermission;
        String mNamePermision;

        public Permission()
        {}

        public Permission(String idPermission, String namePermission)
        {
            MIdPermission = idPermission;
            MNamePermision = namePermission;
        }

        public string MIdPermission
        {
            get
            {
                return mIdPermission;
            }

            set
            {
                mIdPermission = value;
            }
        }

        public string MNamePermision
        {
            get
            {
                return mNamePermision;
            }

            set
            {
                mNamePermision = value;
            }
        }
    }
}
