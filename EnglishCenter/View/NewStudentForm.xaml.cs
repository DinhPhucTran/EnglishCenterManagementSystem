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

        public NewStudentForm()
        {
            InitializeComponent();
            mCaBUS = new CaBUS();
            mThuBUS = new ThuBUS();
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
                bd.Margin = new Thickness( 10, 0, 10, 0);
                ThoiGianRanh_Grid.Children.Add(bd);
            }

            for (int i = 0; i < listCa.Count; i++)
            {
                for (int j = 0; j < listThu.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = listThu[j].MMaThu + "_" + listCa[i].MMaCa;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    ThoiGianRanh_Grid.Children.Add(cb);
                }
            }
        }
    }
}
