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
            DateTime ngayKG, ngayBD, ngayKT;
            try
            {
                ngayKG = (DateTime)dp_ngayKG.SelectedDate;
                ngayBD = (DateTime)dp_ngayBD.SelectedDate;
                ngayKT = (DateTime)dp_ngayKT.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Thời gian nhập vào không hợp lệ");
                return;
            }

            LopHoc lopHoc = new LopHoc();
            lopHoc.MNgayBatDau = ngayBD;
            lopHoc.MNgayKetThuc = ngayKT;
            lopHoc.MNgayKhaiGiang = ngayKG;
            lopHoc.MMaGiangVien = mListGV[cb_Gv.SelectedIndex].MMaGiangVien;
            lopHoc.MMaCTHoc = mListCTH[cb_chuongTrinhHoc.SelectedIndex].MMaChuongTrinhHoc;
            lopHoc.MMaPhong = mListPhong[cb_phong.SelectedIndex].MMaPhong;
            try
            {
                lopHoc.MSoTien = double.Parse(tb_hocPhi.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Học Phí không hợp lệ");
                return;
            }
            
            List<LopHoc> allLop = new LopHocBUS().getListLopHoc();
            long max = getMaxID(allLop)+1;
            lopHoc.MMaLop = mListCTH[cb_chuongTrinhHoc.SelectedIndex].MMaTrinhDo.ToString().Substring(0, 2) + DateTime.Today.Year.ToString() + "."+max;



            bool result = new LopHocBUS().themLopHoc(lopHoc);
            if (!result)
            {
                MessageBox.Show("failed for unknown reason");
            }
            else
                this.Close();
        }

        private long getMaxID(List<LopHoc> list)
        {
            long max = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (max < long.Parse(list[i].MMaLop.ToString().Substring(7)))
                {
                    max = long.Parse(list[i].MMaLop.ToString().Substring(7));
                }
            }
            return max;
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
