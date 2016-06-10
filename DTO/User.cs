using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        String mUsername;
        String mPassword;
        String mPermission;

        public string MUsername
        {
            get
            {
                return mUsername;
            }

            set
            {
                mUsername = value;
            }
        }

        public string MPassword
        {
            get
            {
                return mPassword;
            }

            set
            {
                mPassword = value;
            }
        }

        public string MPermission
        {
            get
            {
                return mPermission;
            }

            set
            {
                mPermission = value;
            }
        }

        public User()
        { }

        public User(String username, String password, String permission)
        {
            MUsername = username;
            MPassword = password;
            MPermission = permission;
        }
    }
}
