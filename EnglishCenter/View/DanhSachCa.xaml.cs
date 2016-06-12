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
    /// Interaction logic for DanhSachCa.xaml
    /// </summary>
    public partial class DanhSachCa: Window
    {
        List<Ca> mListCa;
        CaBUS mCaBUS;

        public DanhSachCa()
        {
            InitializeComponent();
            mListCa = new List<Ca>();
            mCaBUS = new CaBUS();
            mListCa = mCaBUS.getAllCa();
            showListCa();
        }

        public void showListCa()
        {
            parentSP.Orientation = Orientation.Vertical;
            for (int i = 0; i < mListCa.Count; i++)
            {
                StackPanel sp = new StackPanel();
                Label maCa = new Label();
                maCa.Width = ColumnMa.Width;
                maCa.Content = mListCa[i].MMaCa;
                Label tgBD = new Label();
                tgBD.Width = ColumnTGBD.Width;
                tgBD.Content = getTimeFromDateTime(mListCa[i].MThoiGianBatDau);
                Label tgKT = new Label();
                tgKT.Width = ColumnTGKT.Width;
                tgKT.Content = getTimeFromDateTime(mListCa[i].MThoiGianKetThuc);
                maCa.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                tgBD.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                tgKT.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                sp.Children.Add(maCa);
                sp.Children.Add(tgBD);
                sp.Children.Add(tgKT);
                sp.Orientation = Orientation.Horizontal;
                parentSP.Children.Add(sp);
            }
            
        }

        public String getTimeFromDateTime(DateTime d)
        {
            return d.TimeOfDay.ToString();
        }
    }
}
