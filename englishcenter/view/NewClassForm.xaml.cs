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
    /// Interaction logic for NewClassForm.xaml
    /// </summary>
    public partial class NewClassForm : Window
    {
        List<ChuongTrinhHoc> mListCTH;
        List<GiangVien> mListGV;
        List<Phong> mListPhong;
        public NewClassForm()
        {
            InitializeComponent();
            ChuongTrinhHocBUS cthBus = new ChuongTrinhHocBUS();
            mListCTH = cthBus.getListChuongTrinhHoc();
            mListGV = new GiangVienBUS().getListGiangVien();
            mListPhong = new PhongBUS().getListPhong();

            cb_chuongTrinhHoc.ItemsSource = mListCTH;
            cb_chuongTrinhHoc.SelectedIndex = 0;

            cb_Gv.ItemsSource = mListGV;
            cb_Gv.SelectedIndex = 0;

            cb_phong.ItemsSource = mListPhong;
            cb_phong.SelectedIndex = 0;
        }

        private void Button_Luu_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Huy_Click(object sender, RoutedEventArgs e)
        {
            tb_hocPhi.Text = "";
            
        }
    }
}
