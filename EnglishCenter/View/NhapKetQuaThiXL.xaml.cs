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
using System.Text.RegularExpressions;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for NhapKetQuaThiXL.xaml
    /// </summary>
    public partial class NhapKetQuaThiXL : Window
    {
        String mMaThiXL;
        List<ChiTietThiXepLop> mDanhSachChiTietTXL;
        public NhapKetQuaThiXL()
        {
            InitializeComponent();
            List<ThiXepLop> mDanhSachTXL = new ThiXepLopBUS().getTXLNow();
            dsTXL_cb.ItemsSource = mDanhSachTXL;
            //mDanhSachTXL = dsTXL_cb.ItemsSource;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void dsTXL_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mMaThiXL = ((ThiXepLop)dsTXL_cb.SelectedItem).MMaThiXL;
            mDanhSachChiTietTXL = new ChiTietThiXepLopBUS().getChiTietTXLByMaTXL(mMaThiXL);
            List<ChiTietThiXepLop_HocVien> listChiTietTXL_HV = new List<ChiTietThiXepLop_HocVien>();
            HocVienBUS hocVienBus = new HocVienBUS();
            foreach (ChiTietThiXepLop ctxl in mDanhSachChiTietTXL)
            {
                ChiTietThiXepLop_HocVien ct = new ChiTietThiXepLop_HocVien(ctxl, hocVienBus.selectHocVien(ctxl.MMaHocVien));
                listChiTietTXL_HV.Add(ct);
            }

            listHV_lv.ItemsSource = listChiTietTXL_HV;
        }

        private void Luu_btn_Click(object sender, RoutedEventArgs e)
        {
            List<ChiTietThiXepLop> temp = new List<ChiTietThiXepLop>();
            ChiTietThiXepLopBUS ctTXL_BUS = new ChiTietThiXepLopBUS();
            //foreach (ChiTietThiXepLop i in listHV_lv.ItemsSource) 
            foreach (ChiTietThiXepLop i in mDanhSachChiTietTXL) 
            {
                i.MChuongTrinhDeNghi = ctTXL_BUS.getMaCTHocDeNghi(i.MMaThiXepLop, i.MMaHocVien);
                temp.Add(i);
            }
            //anh xa tu chuong trinh mong muon lay ra chuong trinh de nghi cho hoc vien
            //co diem ->  lay ra chuong trinh hoc co diem thap nhat lon hon diem thi va lay min 
            bool flag = new ChiTietThiXepLopBUS().updateKetQuaThi(temp);
            if (flag == false)
            {
                MessageBox.Show("Điểm thi chưa được cập nhật!");
                return;
            }
            MessageBox.Show("Đã lưu");
            //lay chuong trinh de nghi tu diem thi
        }
        
        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void bt_thoat_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
