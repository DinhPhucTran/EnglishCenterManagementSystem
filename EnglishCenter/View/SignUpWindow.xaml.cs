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
using BusinessLogicTier;
using DTO;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public SignUpWindow()
        {
            InitializeComponent();
            cbPermission.ItemsSource = new PermissionBUS().getListPermission();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void signup_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập.");
                return;
            }
            if (tbPass.Password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return;
            }
            if (tbRePass.Password == "")
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu.");
                return;
            }
            if (tbPass.Password != tbRePass.Password)
            {
                MessageBox.Show("Mật khẩu không trùng khớp.");
                return;
            }
            if (new UserBUS().isExist(tbUsername.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                return;
            }
            String idPermission = "";
            if (cbPermission.Text == "")
            {
                MessageBox.Show("Vui lòng chọn quyền truy cập hệ thống cho user.");
                return;
            }
            else
            {
                idPermission = ((Permission)cbPermission.SelectedItem).MIdPermission;
            }

            User user = new User(tbUsername.Text, tbPass.Password, idPermission);
            if (new UserBUS().addUser(user))
            {
                MessageBox.Show("Thêm user thành công.");
                tbUsername.Text = "";
                tbPass.Password = "";
                tbRePass.Password = "";

                //Notify changes
                DataChangedEventHandler handler = DataChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm user thất bại.");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
