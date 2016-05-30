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
    /// Interaction logic for NewStudentForm.xaml
    /// </summary>
    public partial class NewStudentForm : Window
    {
        CaBUS mCaBUS;
        ThuBUS mThuBUS;
        List<CheckBox> mListThoiGianRanh;
        RadioButton mPhaiRadioButton;
        TrinhDoBUS mTrinhDoBUS;
        ChuongTrinhHocBUS mChuongTrinhBUS;
        List<TrinhDo> mListTrinhDo;
        List<ChuongTrinhHoc> mListChuongTrinhHoc;

        public NewStudentForm()
        {
            InitializeComponent();
            mCaBUS = new CaBUS();
            mThuBUS = new ThuBUS();
            mTrinhDoBUS = new TrinhDoBUS();
            mChuongTrinhBUS = new ChuongTrinhHocBUS();
            mListTrinhDo = mTrinhDoBUS.getListTrinhDo();
            mListChuongTrinhHoc = mChuongTrinhBUS.getListChuongTrinhHoc();
            TDoDaHoc_cb.ItemsSource = mListTrinhDo;
            TDoMuonHoc_cb.ItemsSource = mListTrinhDo;
            CTDaHoc_cb.ItemsSource = mListChuongTrinhHoc;
            CTMuonHoc_cb.ItemsSource = mListChuongTrinhHoc;
            createThoiGianRanh();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createThoiGianRanh()
        {
            List<Thu> listThu = mThuBUS.getAllThu();
            List<Ca> listCa = mCaBUS.getAllCa();
            //ThoiGianRanh_Grid.ShowGridLines = true;
            #region ThoiGianRanh_GUI
            for (int i = 0; i <= listCa.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                ThoiGianRanh_Grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i <= listThu.Count; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                ThoiGianRanh_Grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < listThu.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listThu[i].MTenThu;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i + 1);
                ThoiGianRanh_Grid.Children.Add(tb);
            }

            for (int i = 0; i < listCa.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listCa[i].toStringTgBD_TgKT();
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, i + 1);
                Grid.SetColumn(tb, 0);
                ThoiGianRanh_Grid.Children.Add(tb);
                Border bd = new Border();
                Grid.SetRow(bd, i + 1);
                Grid.SetColumn(bd, 0);
                Grid.SetColumnSpan(bd, 8);
                bd.VerticalAlignment = VerticalAlignment.Bottom;
                bd.BorderBrush = Brushes.Gray;
                bd.BorderThickness = new Thickness(0.5);
                bd.Margin = new Thickness(10, 0, 10, 0);
                ThoiGianRanh_Grid.Children.Add(bd);
            }

            mListThoiGianRanh = new List<CheckBox>();

            for (int i = 0; i < listCa.Count; i++)
            {
                for (int j = 0; j < listThu.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = listThu[j].MMaThu + "_" + listCa[i].MMaCa;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    mListThoiGianRanh.Add(cb);
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    ThoiGianRanh_Grid.Children.Add(cb);
                }
            } 
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);
            String temp = "";
            for (int i = 0; i < listChecked.Count; i++)
            {
                temp += listChecked[i].Name + "; ";
            }
            MessageBox.Show(temp);
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            #region GetData
            String ten = TenHocVien_tb.Text;
            if (ten == "")
            {
                MessageBox.Show("Please, fill in your Name!");
                return;
            }
            DateTime? ngaySinh = NgaySinhHV_dp.SelectedDate;
            if (ngaySinh == null)
            {
                MessageBox.Show("Please, choose your Birthday!");
                return;
            }
            if (mPhaiRadioButton == null)
            {
                MessageBox.Show("You are female or male or ...? \n Please, check your Gender!");
                return;
            }
            String phai = mPhaiRadioButton.Content.ToString();
            String diaChi = DiaChi_tb.Text;
            if (diaChi == "")
            {
                MessageBox.Show("Please, enter your Address!");
                return;
            }
            String soDT = SoDT_tb.Text;
            if (soDT == "")
            {
                MessageBox.Show("Please, enter your Phone Number!");
                return;
            }
            String maTDDaHoc = "";
            if (TDoDaHoc_cb.Text != "")
            {
                maTDDaHoc = mTrinhDoBUS.getMaTDFromTen(TDoDaHoc_cb.Text);
            }
            String maTDMuonHoc = "";
            if (TDoMuonHoc_cb.Text != "")
            {
                maTDMuonHoc = mTrinhDoBUS.getMaTDFromTen(TDoMuonHoc_cb.Text);
            }
            String maCTDaHoc = "";
            if (CTDaHoc_cb.Text != "")
            {
                maCTDaHoc = CTDaHoc_cb.Text;
            }
            String maCTMuonHoc = "";
            if (CTMuonHoc_cb.Text != "")
            {
                maCTMuonHoc = CTMuonHoc_cb.Text;
            } 
            #endregion
            HocVien hv = new HocVien("", ten, (DateTime)ngaySinh, phai, diaChi, soDT, maTDDaHoc, maTDMuonHoc, maCTDaHoc, maCTMuonHoc);
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mPhaiRadioButton = (RadioButton)sender;
        }
    }
}
