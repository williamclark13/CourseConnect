using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Project1WilliamClark.CodeBehinds
{
    /// <summary>
    /// Represents the logic for the login page of the application.
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
            if (userService.Login(txtEmail.Text, txtPassword.Password))
            {
                // Navigate to the next page (e.g., user profile page)
            }
            else
            {
                // Display error message
            }
        }
    }
}