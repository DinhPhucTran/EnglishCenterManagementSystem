using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailPermission
    {
        String mIdPermision;
        String mIdTab;

        public DetailPermission()
        { }

        public DetailPermission(String idPermission, String idTab)
        {
            MIdPermision = idPermission;
            MIdTab = idTab;
        }

        public string MIdPermision
        {
            get
            {
                return mIdPermision;
            }

            set
            {
                mIdPermision = value;
            }
        }

        public string MIdTab
        {
            get
            {
                return mIdTab;
            }

            set
            {
                mIdTab = value;
            }
        }
    }
}
