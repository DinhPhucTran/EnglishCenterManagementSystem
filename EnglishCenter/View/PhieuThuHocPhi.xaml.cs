using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PhieuThuHocPhi.xaml
    /// </summary>
    public partial class PhieuThuHocPhi : Window
    {
        List<LopHoc> mListLop;
        private HocVienBUS mHocVienBus;
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;
        public PhieuThuHocPhi()
        {
            mHocVienBus = new HocVienBUS();
            InitializeComponent();
            mListLop = new LopHocBUS().getListLopHoc();
            cb_lop.ItemsSource = mListLop;
            cb_lop.SelectedIndex = 0;

            
            //List<String> listMaHv = mHocVienBus.getMaHVbyMaLop(((LopHoc)cb_lop.SelectedValue).MMaLop);
            //foreach (String ma in listMaHv)
            //{
            //    HocVien hv = mHocVienBus.selectHocVien(ma);
            //    mListHocVien.Add(hv);
            //}
            //cb_tenHocVien.ItemsSource = mListHocVien;
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)//luu
        {
            PhieuThuHocPhiBUS bus = new PhieuThuHocPhiBUS();
            DTO.PhieuThuHocPhi phieu = new DTO.PhieuThuHocPhi();
            List<DTO.PhieuThuHocPhi> list = bus.getDanhSachPhieu();
            long max = 0;
            foreach (DTO.PhieuThuHocPhi p in list)
            {
                if (long.Parse(p.MMaPhieuThu.Substring(6)) > max)
                {
                    max = long.Parse(p.MMaPhieuThu.Substring(6));
                }
            }
            max++;
            phieu.MMaPhieuThu = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + max;

            phieu.MMaLopHoc = ((LopHoc)cb_lop.SelectedValue).MMaLop;
            if(cb_tenHocVien.SelectedValue != null)
                phieu.MMaHocVien = ((HocVien)cb_tenHocVien.SelectedValue).MMaHocVien;
            else
            {
                MessageBox.Show("Vui lòng chọn tên học viên");
                return;
            }
            phieu.MNgayLap = DateTime.Now;
            try
            {
                phieu.MSoTienDong = double.Parse(tb_soTien.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại số tiền");
                return;
            }
            bool result = bus.themPhieuThu(phieu);
            if (result == true)
            {
                MessageBox.Show("Thành Công!");
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu, vui lòng thử lại sau.");
            }

            //Notify changes
            DataChangedEventHandler handler = DataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//in
        {
            MessageBox.Show("Printing...");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//thoat
        {
            this.Close();
        }

        

        private void cb_lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //mListHocVien = new HocVienBUS().getHocVienByMaLop(mListLop[cb_lop.SelectedIndex].MMaLop.ToString());
            //cb_tenHocVien.ItemsSource = mListHocVien;
            //if (mListHocVien.Count != 0)
            //{
            //    cb_tenHocVien.SelectedIndex = 0;
            //}
            
            List<String> listMaHv = mHocVienBus.getMaHVbyMaLop(((LopHoc)cb_lop.SelectedValue).MMaLop);
            List<HocVien> list = new List<HocVien>();
            foreach (String ma in listMaHv)
            {
                HocVien hv = mHocVienBus.selectHocVien(ma);
                list.Add(hv);
            }
            cb_tenHocVien.ItemsSource = list;
            tb_sdt.Text = "";
        }

        private void cb_tenHocVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //tb_sdt.Text = mListHocVien[cb_tenHocVien.SelectedIndex].MSdt;
            if(((HocVien)cb_tenHocVien.SelectedValue) != null)
                tb_sdt.Text = ((HocVien)cb_tenHocVien.SelectedValue).MSdt;
        }



    }
}
