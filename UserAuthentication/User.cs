namespace Project1WilliamClark.UserAuthentication
{
    /// <summary>
    /// Represents a user entity with basic authentication information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class with the specified email, phone number, and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="phoneNumber">The phone number of the user.</param>
        /// <param name="password">The password of the user.</param>
        public User(string email, string phoneNumber, string password) =>
            (Email, PhoneNumber, Password) = (email, phoneNumber, password);
    }
}