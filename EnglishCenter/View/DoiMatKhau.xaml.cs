using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BusinessLogicTier;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        private User mUser;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        public User User
        {
            get { return mUser; }
            set { mUser = value; }
        }

        private void bt_ok_click(object sender, RoutedEventArgs e)
        {
            if(passCu.Password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thống báo");
                return;
            }
            
            if (passMoi.Password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thống báo");
                return;
            }
            if (passXn.Password == "" || !passXn.Password.Equals(passMoi.Password))
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu", "Thống báo");
                return;
            }
            
            UserBUS userBus = new UserBUS();
            if (mUser != null)
            {
                if(!passCu.Password.Equals(mUser.MPassword))
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Thống báo");
                    return;
                }
                if (userBus.updatePassword(mUser.MUsername, passMoi.Password))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "New Age English");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo");
                }
            }
        }

        private void bt_cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
