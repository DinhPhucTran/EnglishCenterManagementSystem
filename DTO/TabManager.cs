using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TabManager
    {
        String mIdTab;
        String mNameTab;

        public TabManager()
        { }

        public TabManager(String idTab, String nameTab)
        {
            MIdTab = idTab;
            MNameTab = nameTab;
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

        public string MNameTab
        {
            get
            {
                return mNameTab;
            }

            set
            {
                mNameTab = value;
            }
        }
    }
}
