using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Project1WilliamClark.CodeBehinds
{
    /// <summary>
    /// Represents the logic for the user profile page, allowing users to update their information.
    /// </summary>
    public partial class UserProfilePage : Page
    {
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the UserProfilePage class.
        /// </summary>
        public UserProfilePage() => InitializeComponent();

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (userService.UpdateUserProfile(txtEmail.Text, txtPassword.Text, txtNewEmail.Text, txtNewPhoneNumber.Text))
            {
                // Display success message
            }
            else
            {
                // Display error message
            }
        }
    }
}