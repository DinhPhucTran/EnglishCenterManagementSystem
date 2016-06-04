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
    
    
    public partial class ThemLichThi : Window
    {
        List<Phong> mListPhong;
        public ThemLichThi()
        {
            InitializeComponent();
            mListPhong = new PhongBUS().getListPhong();
            cb_phongThi.ItemsSource = mListPhong;
            cb_phongThi.SelectedIndex = 0;

            cb_caThi.ItemsSource = new CaBUS().getAllCa();
            cb_caThi.SelectedIndex = 0;

            cb_deThi.ItemsSource = new DeThiBUS().getListDeThi();
            cb_deThi.SelectedIndex = 0;

            
        }

        private void Button_Huy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Luu_Click(object sender, RoutedEventArgs e)
        {
            ThiXepLop txl = new ThiXepLop();
            txl.MCaThi = new CaBUS().getAllCa()[cb_caThi.SelectedIndex].MMaCa;
            txl.MDeThi = new DeThiBUS().getListDeThi()[cb_deThi.SelectedIndex].MMaDeThi;
            txl.MMaPhong = mListPhong[cb_phongThi.SelectedIndex].MMaPhong;
            try
            {
                txl.MNgayThi = (DateTime)dp_ngayThi.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày tháng không hợp lệ");
                return;
            }
            
            int result = new ThiXepLopBUS().themThiXepLop(txl);
            if (result != 1)
            {
                MessageBox.Show("Thêm thất bại. Lịch thi đả tồn tại hoặc lổi kết nối vào database\nresult code: " + result);
            }
            else
            {
                this.Close();
            }
        }
        private void Button_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
