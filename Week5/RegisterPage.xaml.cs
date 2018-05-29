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
using Week5.ShopService;
    
namespace Week5
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {

        private RegisterService service = new RegisterService();

        public RegisterPage()
        {
            InitializeComponent();
            password.Text = service.GeneratePassword();
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            if (username.Length <= 2)
            {
                errorText.Text = "Username is too short";
                return;
            }
            service.AccountExists(username, out bool exists, out bool exists2);
            if (exists)
            {
                errorText.Text = "Username is invalid";
                return;
            }
            service.Register(username, password.Text);
            errorText.Text = "User created!";
        }
    }
}
