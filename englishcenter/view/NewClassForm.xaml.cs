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

        CaBUS mCaBUS;
        ThuBUS mThuBUS;
        ThoiGianHocBUS mTghBUS;
        List<CheckBox> mListThoiGianHoc;

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public NewClassForm()
        {
            InitializeComponent();
            mCaBUS = new CaBUS();
            mThuBUS = new ThuBUS();
            mTghBUS = new ThoiGianHocBUS();

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

            createThoiGianHoc();
            dp_ngayBD.SelectedDate = DateTime.Today;
        }

        public NewClassForm(LopHoc lop)
        {
            InitializeComponent();
            mCaBUS = new CaBUS();
            mThuBUS = new ThuBUS();
            mTghBUS = new ThoiGianHocBUS();

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

            createThoiGianHoc();
        }

        private void initBoxes(LopHoc lop)
        {
            tb_hocPhi.Text = lop.MSoTien.ToString();
            dp_ngayBD.SelectedDate = lop.MNgayBatDau;
            dp_ngayKT.SelectedDate = lop.MNgayKetThuc;
            dp_ngayKG.SelectedDate = lop.MNgayKhaiGiang;
            for (int i = 0; i < mListCTH.Count; i++)
            {
                //if(mListCTH[i].)
            }
        }

        private void Button_Luu_Click(object sender, RoutedEventArgs e)
        {
            DateTime ngayKG, ngayBD, ngayKT;
            try
            {
                ngayKG = (DateTime)dp_ngayKG.SelectedDate;
                ngayBD = (DateTime)dp_ngayBD.SelectedDate;
                ngayKT = (DateTime)dp_ngayKT.SelectedDate;
                if (ngayKT.CompareTo(ngayBD) <= 0)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                    return;
                }
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

            //kiểm tra tính hợp lệ trước khi thêm vào
            List<ThoiGianHoc> selectedThoiGianHoc = getSelectedThoiGianHoc(lopHoc.MMaLop);

            List<LopHoc> listLopHoc = new LopHocBUS().getListLopHocByTime(lopHoc.MNgayBatDau, lopHoc.MNgayKetThuc);
            foreach (LopHoc lp in listLopHoc)
            {
                if (lp.MMaPhong.Equals(lopHoc.MMaPhong))//2 lớp cùng phòng
                {
                    //kiểm tra xem có trung thời gian
                    List<ThoiGianHoc> lpThoiGianHoc = mTghBUS.getThoiGianHocCuaLop(lp.MMaLop);
                    for (int i = 0; i < selectedThoiGianHoc.Count; ++i)
                    {
                        for (int j = 0; j < lpThoiGianHoc.Count; ++j)
                        {
                            if (selectedThoiGianHoc[i].kiemTraTrungThoiGian(lpThoiGianHoc[j]) == true)
                            {
                                MessageBox.Show("Thời gian đã chọn trùng thời gian với lớp: " + lp.MMaLop + " - phòng: " + lp.MMaPhong);
                                return;
                            }
                        }
                    }
                }
            }

            bool result = new LopHocBUS().themLopHoc(lopHoc);
            if (!result)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau.");
                return;
            }
            else
            {
                if (selectedThoiGianHoc.Count != mTghBUS.themDanhSachThoiGianHoc(selectedThoiGianHoc))//lổi 
                {
                    mTghBUS.xoaThoiGianHocCuaLop(lopHoc.MMaLop);
                    new LopHocBUS().xoaLopHoc(lopHoc.MMaLop);
                    MessageBox.Show("Không thể thêm thời gian học, vui lòng thử lại sau.");
                    return;
                }
                MessageBox.Show("Thêm thành công!");
            }

            //Notify changes
            DataChangedEventHandler handler = DataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private List<ThoiGianHoc> getSelectedThoiGianHoc(String maLop)
        {
            List<ThoiGianHoc> result = new List<ThoiGianHoc>();
          

            foreach (CheckBox cb in mListThoiGianHoc)
            {
                if (cb.IsChecked == true)
                {
                    ThoiGianHoc tgh = new ThoiGianHoc();
                    tgh.MMaLop = maLop;
                    string [] words = cb.Name.ToString().Split('_');
                    tgh.MMaThu = words[0];
                    tgh.MMaCa = words[1];
                    result.Add(tgh);
                }
            }
            return result;
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

        private void createThoiGianHoc()
        {
            //List<Thu> listThu = mThuBUS.getAllThu();
            List<Thu> listThu = new List<Thu>();
            listThu.Add(new Thu("Monday", "Thứ Hai"));
            listThu.Add(new Thu("Tuesday", "Thứ Ba"));
            listThu.Add(new Thu("Wednesday", "Thứ Tư"));
            listThu.Add(new Thu("Thursday", "Thứ Năm"));
            listThu.Add(new Thu("Friday", "Thứ Sáu"));
            listThu.Add(new Thu("Saturday", "Thứ Bảy"));
            listThu.Add(new Thu("Sunday", "Chủ Nhật"));

            List<Ca> listCa = mCaBUS.getAllCa();
            //ThoiGianHoc_Grid.ShowGridLines = true;
            #region ThoiGianRanh_GUI
            for (int i = 0; i <= listCa.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                ThoiGianHoc_Grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i <= listThu.Count; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                ThoiGianHoc_Grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < listThu.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listThu[i].MTenThu;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i + 1);
                ThoiGianHoc_Grid.Children.Add(tb);
            }

            for (int i = 0; i < listCa.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listCa[i].toStringTgBD_TgKT();
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, i + 1);
                Grid.SetColumn(tb, 0);
                ThoiGianHoc_Grid.Children.Add(tb);
                Border bd = new Border();
                Grid.SetRow(bd, i + 1);
                Grid.SetColumn(bd, 0);
                Grid.SetColumnSpan(bd, 8);
                bd.VerticalAlignment = VerticalAlignment.Bottom;
                bd.BorderBrush = Brushes.Gray;
                bd.BorderThickness = new Thickness(0.5);
                bd.Margin = new Thickness(10, 0, 10, 0);
                ThoiGianHoc_Grid.Children.Add(bd);
            }

            mListThoiGianHoc = new List<CheckBox>();

            for (int i = 0; i < listCa.Count; i++)
            {
                for (int j = 0; j < listThu.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = listThu[j].MMaThu + "_" + listCa[i].MMaCa;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    mListThoiGianHoc.Add(cb);
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    ThoiGianHoc_Grid.Children.Add(cb);
                }
            }
            #endregion
        }
    }
}
