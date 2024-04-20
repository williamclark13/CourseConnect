using Project1WilliamClark.UserAuthentication;
using System;
using System.IO;

namespace Project1WilliamClark.Testing
{
    public class UserServiceTests
    {
        private UserService userService;
        private string testFilePath = "test_users.json";

        public void Setup()
        {
            userService = new UserService();
        }

        public void Teardown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        public void Signup_ValidData_ReturnsTrue()
        {
            string email = "test@example.com";
            string phoneNumber = "1234567890";
            string password = "password";
            bool result = userService.Signup(email, phoneNumber, password);
            if (!result)
                throw new Exception("Signup_ValidData_ReturnsTrue test failed");
        }

        public void Login_ValidCredentials_ReturnsTrue()
        {
            string email = "test@example.com";
            string password = "password";
            userService.Signup(email, "1234567890", password);
            bool result = userService.Login(email, password);
            if (!result)
                throw new Exception("Login_ValidCredentials_ReturnsTrue test failed");
        }

        public void UpdateUserProfile_ValidData_ReturnsTrue()
        {
            string email = "test@example.com";
            string password = "password";
            string newEmail = "newemail@example.com";
            string newPhoneNumber = "9876543210";
            userService.Signup(email, "1234567890", password);
            bool result = userService.UpdateUserProfile(email, password, newEmail, newPhoneNumber);
            if (!result)
                throw new Exception("UpdateUserProfile_ValidData_ReturnsTrue test failed");
        }

        public void RunAllTests()
        {
            Setup();
            try
            {
                Signup_ValidData_ReturnsTrue();
                Login_ValidCredentials_ReturnsTrue();
                UpdateUserProfile_ValidData_ReturnsTrue();
                Console.WriteLine("All tests passed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
            }
            finally
            {
                Teardown();
            }
        }
    }
}