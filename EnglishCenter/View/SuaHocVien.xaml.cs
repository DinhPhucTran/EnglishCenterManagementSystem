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
using System.Text.RegularExpressions;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for SuaHocVien.xaml
    /// </summary>
    public partial class SuaHocVien : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;
        private RadioButton mPhaiRadioButton;
        private TrinhDoBUS mTrinhDoBUS;
        private ChuongTrinhHocBUS mChuongTrinhBUS;
        private HocVienBUS mHocVienBUS;
        private List<TrinhDo> mListTrinhDo;
        private List<ChuongTrinhHoc> mListCTH;
        private HocVien hocVien;
        public SuaHocVien()
        {
            //InitializeComponent();
            //initTextBoxes();
            //mTrinhDoBUS = new TrinhDoBUS();
            //mChuongTrinhBUS = new ChuongTrinhHocBUS();
            //mHocVienBUS = new HocVienBUS();
            //mListTrinhDo = mTrinhDoBUS.getListTrinhDo();
            //mListCTH = mChuongTrinhBUS.getListChuongTrinhHoc();

            ////cb_ctDaHoc.SelectedValuePath = "MTenChuongTrinhHoc";
            ////cb_ctMuonHoc.SelectedValuePath = "MTenChuongTrinhHoc";
            ////cb_tdDaHoc.SelectedValuePath = "MTenTrinhDo";
            ////cb_tdMuonHoc.SelectedValuePath = "MTenTrinhDo";
            //cb_ctDaHoc.ItemsSource = mListCTH;
            //cb_ctMuonHoc.ItemsSource = mListCTH;
            //cb_tdDaHoc.ItemsSource = mListTrinhDo;
            //cb_tdMuonHoc.ItemsSource = mListTrinhDo;
        }

        public SuaHocVien(HocVien hv)
        {
            InitializeComponent();
            hocVien = hv;
            mTrinhDoBUS = new TrinhDoBUS();
            mChuongTrinhBUS = new ChuongTrinhHocBUS();
            mHocVienBUS = new HocVienBUS();
            //mListTrinhDo = mTrinhDoBUS.getListTrinhDo();
            //mListCTH = mChuongTrinhBUS.getListChuongTrinhHoc();

            //cb_ctDaHoc.SelectedValuePath = "MTenChuongTrinhHoc";
            //cb_ctMuonHoc.SelectedValuePath = "MTenChuongTrinhHoc";
            //cb_tdDaHoc.SelectedValuePath = "MTenTrinhDo";
            //cb_tdMuonHoc.SelectedValuePath = "MTenTrinhDo";
            //cb_ctDaHoc.ItemsSource = mListCTH;
            //cb_ctMuonHoc.ItemsSource = mListCTH;
            //cb_tdDaHoc.ItemsSource = mListTrinhDo;
            //cb_tdMuonHoc.ItemsSource = mListTrinhDo;
            initTextBoxes();
        }

        public HocVien HocVien
        {
            get { return hocVien; }
            set { hocVien = value; }
        }

        public void initTextBoxes()
        {
            tb_tenHocVien.Text = hocVien.MTenHocVien;
            tb_Sdt.Text = hocVien.MSdt;
            tb_diaChi.Text = hocVien.MDiaChi;
            tb_email.Text = hocVien.MEmail;
            datePicker_ngaySinh.SelectedDate = hocVien.MNgaySinh;
            if (hocVien.MPhai.Equals("Nam"))
                rb_nam.IsChecked = true;
            else if (hocVien.MPhai.Equals("Nữ"))
                rb_nu.IsChecked = true;
            else if (hocVien.MPhai.Equals("Khác"))
                rb_khac.IsChecked = true;
            //try
            //{
            //    cb_ctMuonHoc.SelectedValue = mChuongTrinhBUS.getTenChuongTrinhHocByMa(hocVien.MMaChuongTrinhMuonHoc);
            //    cb_ctDaHoc.SelectedValue = mChuongTrinhBUS.getTenChuongTrinhHocByMa(hocVien.MMaChuongTrinhDaHoc);
            //    cb_tdDaHoc.SelectedValue = mTrinhDoBUS.selectTrinhDo(hocVien.MMaTrinhDoDaHoc).MTenTrinhDo;
            //    cb_tdMuonHoc.SelectedValue = mTrinhDoBUS.selectTrinhDo(hocVien.MMaTrinhDoMuonHoc).MTenTrinhDo;

                
            //}
            //catch (Exception)
            //{

            //}
          
        }

        private void bt_luu_click(object sender, RoutedEventArgs e)
        {
            String ten = tb_tenHocVien.Text;
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên học viên.", "Thông báo");
                return;
            }
            DateTime? ngaySinh = datePicker_ngaySinh.SelectedDate;
            if (ngaySinh == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.", "Thông báo");
                return;
            }
            if (mPhaiRadioButton == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo");
                return;
            }
            String phai = mPhaiRadioButton.Content.ToString();
            String diaChi = tb_diaChi.Text;
            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo");
                return;
            }

            String soDT = tb_Sdt.Text;
            if (soDT == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo");
                return;
            }

            //String maTDDaHoc = null;
            //if (cb_tdDaHoc.Text != "")
            //{
            //    maTDDaHoc = mTrinhDoBUS.getMaTDFromTen(cb_tdDaHoc.Text);
            //}
            //String maTDMuonHoc = null;
            //if (cb_tdMuonHoc.Text != "")
            //{
            //    maTDMuonHoc = mTrinhDoBUS.getMaTDFromTen(cb_tdMuonHoc.Text);
            //}
            //String maCTDaHoc = null;
            //if (cb_ctDaHoc.Text != "")
            //{
            //    maCTDaHoc = mChuongTrinhBUS.getMaCTFromTenCT(cb_ctDaHoc.Text);
            //}
            //String maCTMuonHoc = null;
            //if (cb_ctMuonHoc.Text != "")
            //{
            //    maCTMuonHoc = mChuongTrinhBUS.getMaCTFromTenCT(cb_ctMuonHoc.Text);
            //}

            HocVien hv = new HocVien(hocVien.MMaHocVien, ten, (DateTime)ngaySinh, phai, diaChi, tb_email.Text, soDT);

            if (!mHocVienBUS.updateHocVien(hv))
            {
                MessageBox.Show("Sửa thông tin học viên thất bại!");
            }
            else
            {
                MessageBox.Show("Đã cập nhật thông tin học viên.", "New Age English");
                //Notify changes
                DataChangedEventHandler handler = DataChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mPhaiRadioButton = (RadioButton)sender;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void bt_huy_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
