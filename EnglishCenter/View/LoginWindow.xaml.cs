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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MainWindow mainWindow;
        public LoginWindow()
        {
            InitializeComponent();
            mainWindow = new MainWindow();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //App.Current.Shutdown();
            this.Close();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không đúng.");
                return;
            }
            if (tbPass.Password == "")
            {
                MessageBox.Show("Mật khẩu không đúng.");
                return;
            }
            User user = new User(tbUsername.Text, tbPass.Password, "");
            if (new UserBUS().checkUser(user)) {
                mainWindow.Show();
                this.Close();
                foreach (Button btn in FindVisualChildren<Button>(mainWindow))
                {
                    if (btn.Name == "btn_AddStudent")
                    {
                        //btn.Visibility = Visibility.Hidden;
                    }
                }
            }                
            else
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            
        }
    }
}
