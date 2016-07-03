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

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for LoginError.xaml
    /// </summary>
    public partial class LoginError : Window
    {
        public LoginError()
        {
            InitializeComponent();
        }

        private void bt_exit_click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void bt_edit_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa connection string?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    EditConnectionString edit = new EditConnectionString(); //Hiện của sổ sửa connection string
                    edit.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    App.Current.Shutdown();
                    break;
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
