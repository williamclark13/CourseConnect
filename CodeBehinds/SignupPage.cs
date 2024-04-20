using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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
            if (userService.Signup(txtEmail.Text, txtPhoneNumber.Text, txtPassword.Password))
            {
                // Navigate to the next page (e.g., login page)
            }
            else
            {
                // Display error message
            }
        }
    }
}