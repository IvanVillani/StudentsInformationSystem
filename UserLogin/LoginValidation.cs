using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private String _username;
        private String _password;
        private String _errorLog;

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError _onError;
        public static String currentUserUsername { get; private set; }
        public static UserRoles currentUserRole { get; private set; }

        public LoginValidation(String username, String password, ActionOnError action)
        {
            _username = username;
            _password = password;
            _onError = action;
        }
        public bool ValidateUserInput(User user)
        {
            Boolean emptyUserName, shortUserName;

            emptyUserName = _username.Equals(String.Empty);
            shortUserName = _username.Length < 5;

            if (emptyUserName == true)
            {
                _errorLog = "Username not specified";
                _onError(_errorLog);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (shortUserName == true)
            {
                _errorLog = "Username must 5 or more symbols";
                _onError(_errorLog);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            Boolean emptyPassword, shortPassword;

            emptyPassword = _password.Equals(String.Empty);
            shortPassword = _password.Length < 5;

            if (emptyPassword == true)
            {
                _errorLog = "Password not specified";
                _onError(_errorLog);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (shortPassword == true)
            {
                _errorLog = "Password must be 5 or more symbols";
                _onError(_errorLog);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            User foundUser = UserData.IsUserPassCorrect(_username, _password);

            if (foundUser == null)
            {
                _errorLog = "Wrong username and/or password";
                _onError(_errorLog);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            
            currentUserRole = (UserRoles)foundUser.Role;
            currentUserUsername = foundUser.Username;
            
            Logger.LogActivity("Successful Login");

            user.Username = foundUser.Username;
            user.Password = foundUser.Password;
            user.FakNum = foundUser.FakNum;
            user.Role = foundUser.Role;

            return true;
        }
    }
}
