/* 
 * This class will store a global boolean to determine if the user is logged in and
 * the user type
 */

namespace CPMS.Models
{
    public static class LoginManager
    {
        public static string? Username;

        //is the user currently logged in?
        public static bool? IsLoggedIn;

        //is the user an author, reviewer, or an admin?n
        public static string? UserType;

        public static int? UserId;

        //is the user an admin?
        public static bool? Admin;

        public static int? LoginAttempts = 0;

        //logout method clears all login info
        public static void Logout()
        {
            Username = null;
            IsLoggedIn = false;
            UserType = null;
            UserId = null;
            Admin = false;
            LoginAttempts = 0;
        }

        //check for any common SQL injection patterns in our login string before performing SQL query
        public static bool CheckValidityOfLogin(string Username, string Password)
        {
            //fals if empty
            if (string.IsNullOrEmpty(Username)) return false;
            if (string.IsNullOrEmpty(Password)) return false;

            //check if the username or password starts or ends with a ' character (common sign of SQL injection)
            if (Username[0] == '\'') return false;
            if (Password[0] == '\'') return false;
            if (Username[Username.Length - 1] == '\'') return false;
            if (Password[Password.Length - 1] == '\'') return false;

            return true;
        }

        //check if the user has had too many failed logins or is already logged in
        public static bool CanLogIn()
        {
            //if they're already logged in don't let them log back in
            if (IsLoggedIn == true) return false;

            //if they've failed to log in 3 times lock them out
            if (LoginAttempts > 2) return false;
            else return true;
        }

        //check if the user is an admin
        public static bool IsAdmin(string? username, string? password)
        {
            if(username == null || password == null) return false;

            //we are hardcoding the admin login for now (assignment instructions)

            //TO DO: in future system update allow for a multi-admin login system

            //hard-coded login and password
            string  AdminUsername = "admin";
            string AdminPassword = "smith";

            //verify if the user is an admin
            if (username == AdminUsername && password == AdminPassword)
            {
                //set admin statis to true
                Admin = true;
                Username = username;
                IsLoggedIn = true;
                return true;
            }
            else return false;
        }

        //overload the IsAdmin method to return the admin boolean
        public static bool IsAdmin()
        {
            return Admin == true;
        }
    }
}
