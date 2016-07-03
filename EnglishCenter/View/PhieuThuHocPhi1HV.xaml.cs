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
using System.Text.RegularExpressions;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for PhieuThuHocPhi1HV.xaml
    /// </summary>
    public partial class PhieuThuHocPhi1HV : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public PhieuThuHocPhi1HV()
        {
            InitializeComponent();
            tb_Date.Text = DateTime.Now.ToShortDateString();
        }

        public String MaHocVien { get; set; }
        
        public TextBlock Lop
        {
            set { tb_lop = value; }
        }

        public TextBlock TenHocVien
        {
            set { tb_tenHocVien = value; }
        }

        public TextBlock SoDienThoai
        {
            set { tb_sdt = value; }
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

            phieu.MMaLopHoc = tb_lop.Text;
            phieu.MMaHocVien = MaHocVien;
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
                bool result1 = new PhieuThuHocPhiBUS().updateSoTienNo(phieu.MMaHocVien, phieu.MMaLopHoc, phieu.MSoTienDong);
                tb_soTienNo.Text = new ChiTietLopHocBUS().selectChiTietLopHocByMaHV(phieu.MMaHocVien).MSoTienNo.ToString();
                tb_soTien.Text = "";
                if (result1 == true)
                {
                    MessageBox.Show("Đã lưu.");
                    //Notify changes
                    DataChangedEventHandler handler = DataChanged;
                    if (handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lưu dữ liệu, vui lòng thử lại sau. Lổi cập nhật số tiền nợ");
                }
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu, vui lòng thử lại sau.");
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
    }
}
