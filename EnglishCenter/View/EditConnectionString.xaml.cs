using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for EditConnectionString.xaml
    /// </summary>
    public partial class EditConnectionString : Window
    {
        public EditConnectionString()
        {
            InitializeComponent();
            tb_conString.Text = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        private void bt_huy_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Lưu connection string vào file config
        private void bt_luu_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString = tb_conString.Text;
                configuration.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                MessageBox.Show("Đã lưu", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau. " + e.ToString(), "Thông báo");
            }
        }

        //Đăng nhập lại sau khi đã sửa connection string
        private void bt_dangNhap_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString = tb_conString.Text;
                configuration.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                LoginWindow login = new LoginWindow();
                login.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau.", "Thông báo");
            }            
        }
    }
}
