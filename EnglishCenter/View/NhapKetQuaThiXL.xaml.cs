﻿using System;
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
            List<ChiTietThiXepLop> mDanhSachChiTietTXL = new ChiTietThiXepLopBUS().getChiTietTXLByMaTXL(mMaThiXL);
            listHV_lv.ItemsSource = mDanhSachChiTietTXL;
        }

        private void Luu_btn_Click(object sender, RoutedEventArgs e)
        {
            List<ChiTietThiXepLop> temp = new List<ChiTietThiXepLop>();
            //lấy lớp thi xếp lớp hiện tại
            ThiXepLop txlHienTai = new ThiXepLopBUS().selectThiXLByMaTXL(mMaThiXL);
            //lấy ra mã đề thi và loại đề thi, sau khi lấy loại đề thi lấy ra chương trình thi
            foreach(ChiTietThiXepLop i in listHV_lv.ItemsSource)
            {
                temp.Add(i);
            }
            bool flag = new ChiTietThiXepLopBUS().updateKetQuaThi(temp);
            if (flag == false)
            {
                MessageBox.Show("Điểm thi chưa được cập nhật!");
                return;
            }
            //lay chuong trinh de nghi tu diem thi
        }
    }
}
