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
    /// Interaction logic for NewClassRoom.xaml
    /// </summary>
    public partial class NewClassRoom : Window
    {
        PhongBUS mPhongBUS;
        List<Phong> mDanhSachPhong;

        public NewClassRoom()
        {
            InitializeComponent();
            mPhongBUS = new PhongBUS();
            mDanhSachPhong = mPhongBUS.getListPhong();
            if (mDanhSachPhong.Count != 0)
            {
                dsPhong_lv.ItemsSource = mDanhSachPhong;
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (TenPhong_tb.Text == "" || isTheSameNameRoom())
            {
                MessageBox.Show("Phòng trùng tên. \nVui lòng nhập lại!", "Lỗi");
                return;
            }
            mPhongBUS.themPhong(new Phong("", TenPhong_tb.Text));
            MessageBox.Show("Phòng đã được thêm.");
            dsPhong_lv.UpdateLayout();
            dsPhong_lv.ItemsSource = mPhongBUS.getListPhong();
        }

        public bool isTheSameNameRoom()
        {
            Phong p = mDanhSachPhong.Find(m => m.MTenPhong.ToLower() == TenPhong_tb.Text.ToLower());
            if (p != null)
            {
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
