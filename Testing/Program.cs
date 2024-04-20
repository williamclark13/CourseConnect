using Project1WilliamClark.Testing;

namespace Project1WilliamClark.UserAuthentication
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main()
        {
            UserServiceTests userServiceTests = new UserServiceTests();
            userServiceTests.RunAllTests();

            UserService userService = new UserService();
            userService.SaveSignupToJson("example@example.com", "1234567890", "password", "signup.json");
            userService.SaveLoginToJson("example@example.com", "password", "login.json");
            userService.SaveUpdateUserProfileToJson("example@example.com", "password", "new@example.com", "0987654321", "update.json");
        }
    }
}