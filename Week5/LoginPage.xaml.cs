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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week5.LogService;

namespace Week5
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private LoginService service = new LoginService();

        public LoginPage() 
        {
            InitializeComponent();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            if (username.Length < 1 || password.Length < 1)
            {
                errorText.Text = "Insert your username and password.";
                return;
            }
            service.Authenticate(username, password, out bool succes, out bool success2);
            if (!succes)
            {
                errorText.Text = "Invalid username or password";
                return;
            }

            Window storeWindow = new StoreWindow(username);
            storeWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
