using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace Project1WilliamClark.CodeBehinds
{
    /// <summary>
    /// Represents the logic for the signup page where new users can register.
    /// </summary>
    public partial class SignupPage : Page
    {
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the SignupPage class.
        /// </summary>
        public SignupPage() => InitializeComponent();

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            userService.Signup(txtEmail.Text, txtPhoneNumber.Text, txtPassword.Text);
            Frame.Navigate(typeof(UserProfilePage));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}