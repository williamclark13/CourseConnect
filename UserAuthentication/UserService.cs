using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using Formatting = Newtonsoft.Json.Formatting;
using Newtonsoft.Json;

namespace Project1WilliamClark.UserAuthentication
{
    /// <summary>
    /// Provides services for user authentication such as signup, login, and profile updates.
    /// </summary>
    public class UserService
    {
        private readonly List<User> users = new List<User>();

        /// <summary>
        /// Registers a new user with the provided email, phone number, and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="phoneNumber">The phone number of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the signup was successful, otherwise false.</returns>
        public bool Signup(string email, string phoneNumber, string password)
        {
            try
            {
                if (!IsValidEmail(email))
                    throw new FormatException("Invalid email format.");
                if (!IsValidPhoneNumber(phoneNumber))
                    throw new FormatException("Invalid phone number format.");
                if (IsUserExists(email))
                {
                    Console.WriteLine("User already exists.");
                    return false;
                }

                users.Add(new User(email, phoneNumber, password));
                Console.WriteLine("Signup successful.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Authenticates a user based on the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the login was successful, otherwise false.</returns>
        public bool Login(string email, string password)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Email == email);
                if (user == null || user.Password != password)
                    throw new InvalidOperationException("Invalid email or password.");

                Console.WriteLine("Login successful.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Updates the profile of a user with the specified email and password.
        /// </summary>
        /// <param name="email">The current email address of the user.</param>
        /// <param name="password">The current password of the user.</param>
        /// <param name="newEmail">The new email address to update.</param>
        /// <param name="newPhoneNumber">The new phone number to update.</param>
        /// <returns>True if the profile update was successful, otherwise false.</returns>
        public bool UpdateUserProfile(string email, string password, string newEmail, string newPhoneNumber)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                    throw new InvalidOperationException("Invalid email or password.");
                if (!IsValidEmail(newEmail))
                    throw new FormatException("Invalid new email format.");
                if (!IsValidPhoneNumber(newPhoneNumber))
                    throw new FormatException("Invalid new phone number format.");

                user.Email = newEmail;
                user.PhoneNumber = newPhoneNumber;
                Console.WriteLine("User profile updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if the provided email address is in a valid format.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid, otherwise false.</returns>
        private bool IsValidEmail(string email) => !string.IsNullOrEmpty(email) && email.Contains("@");

        /// <summary>
        /// Checks if the provided phone number is in a valid format.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid, otherwise false.</returns>
        private bool IsValidPhoneNumber(string phoneNumber) => !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _);

        /// <summary>
        /// Checks if a user with the provided email address already exists.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns>True if a user with the provided email address exists, otherwise false.</returns>
        private bool IsUserExists(string email) => users.Exists(u => u.Email == email);

        /// <summary>
        /// Saves the user signup data to a JSON file.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="phoneNumber">The phone number of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="filePath">The file path where the JSON data will be saved.</param>
        public void SaveSignupToJson(string email, string phoneNumber, string password, string filePath)
        {
            Signup(email, phoneNumber, password);
            SaveUsersToJson(filePath);
        }

        /// <summary>
        /// Saves the user login data to a JSON file.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="filePath">The file path where the JSON data will be saved.</param>
        public void SaveLoginToJson(string email, string password, string filePath)
        {
            Login(email, password);
            SaveUsersToJson(filePath);
        }

        /// <summary>
        /// Saves the updated user profile data to a JSON file.
        /// </summary>
        /// <param name="email">The current email address of the user.</param>
        /// <param name="password">The current password of the user.</param>
        /// <param name="newEmail">The new email address to update.</param>
        /// <param name="newPhoneNumber">The new phone number to update.</param>
        /// <param name="filePath">The file path where the JSON data will be saved.</param>
        public void SaveUpdateUserProfileToJson(string email, string password, string newEmail, string newPhoneNumber, string filePath)
        {
            UpdateUserProfile(email, password, newEmail, newPhoneNumber);
            SaveUsersToJson(filePath);
        }

        /// <summary>
        /// Saves the user data to a JSON file.
        /// </summary>
        /// <param name="filePath">The file path where the JSON data will be saved.</param>
        private void SaveUsersToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}