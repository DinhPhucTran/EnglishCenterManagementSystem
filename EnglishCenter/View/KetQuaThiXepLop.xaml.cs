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
    /// Interaction logic for KetQuaThiXepLop.xaml
    /// </summary>
    public partial class KetQuaThiXepLop : Window
    {
        private List<KetQuaThi> mList;
        private KetQuaThiXLBUS mBUS;
        public KetQuaThiXepLop()
        {
            mBUS =  new KetQuaThiXLBUS();
            InitializeComponent();
            try
            {
                List<DateTime> khoangTG = new ThiXepLopBUS().getKhoangThoiGianLayThiXepLop(DateTime.Now);
                mList = mBUS.getKetQuaThi(khoangTG[0], khoangTG[1]);
                lv_ketQua.ItemsSource = mList;
                foreach (KetQuaThi kqt in mList)
                {
                    List<string> cb_lopDeNghi = new KetQuaThiXLBUS().getMaLopDeNghiVaMongMuon(kqt.MChuongTrinhDeNghi, kqt.MChuongTrinhMuonHoc, kqt.MNgayThi);

                    kqt.MMaLopDeNghi = cb_lopDeNghi;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa có lớp mới!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cb_lopDeNghi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            KetQuaThi kqt = (KetQuaThi)cb.DataContext;
            kqt.MSelectedMaLop = cb.SelectedIndex;
            if (!cb.Text.Equals(""))
            {
                MessageBox.Show(kqt.MTenHV+ " - "+kqt.MMaLopDeNghi[kqt.MSelectedMaLop]);
            }
        }

        private void Button_Click_Luu(object sender, RoutedEventArgs e)
        {
            foreach (KetQuaThi kqt in mList)
            {
                if (kqt.MMaLopDeNghi.Count != 0)
                {
                    ChiTietLopHoc ctlh = new ChiTietLopHoc();
                    ctlh.MMaLopHoc = kqt.MMaLopDeNghi[kqt.MSelectedMaLop];
                    ctlh.MMaHocVien = kqt.mMaHV;
                    ctlh.MTinhTrangDongHocPhi = 0;
                    ctlh.MSoTienNo = new LopHocBUS().selectLopHoc(ctlh.MMaLopHoc).MSoTien;
                    ctlh.MKetQuaThi = kqt.MKetQua;
                    
                    bool result = new ChiTietLopHocBUS().insertChiTietLopHoc(ctlh);
                    if (result == false)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau.");
                    }
                    else
                    {
                        MessageBox.Show("Đã lưu!");
                        this.Close();
                    }
                }
            }
        }
        private void Button_Click_Thoat(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
