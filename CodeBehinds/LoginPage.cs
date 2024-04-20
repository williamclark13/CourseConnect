using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace Project1WilliamClark.CodeBehinds
{
    /// <summary>
    /// Represents the logic for the login page where users can sign in.
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        public LoginPage() => InitializeComponent();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (userService.Login(txtEmail.Text, txtPassword.Text))
            {
                Frame.Navigate(typeof(UserProfilePage));
            }
            else
            {
                Debug.WriteLine("Error: Login failed. Please check your email and password and try again.");
            }
        }
    }
}