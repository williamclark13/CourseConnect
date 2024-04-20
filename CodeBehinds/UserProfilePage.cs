using Project1WilliamClark.UserAuthentication;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Diagnostics;

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
                Debug.WriteLine("User profile updated successfully.");
            }
            else
            {
                Debug.WriteLine("Error: Unable to update user profile. Please check your inputs and try again.");
            }
        }
    }
}