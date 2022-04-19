using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var loginInformation = parameter as LoginInformation;

            String username = loginInformation.Username;
            String password = loginInformation.Password;

            UserLogin.LoginValidation.ActionOnError action = new UserLogin.LoginValidation.ActionOnError(ReportError);

            UserLogin.LoginValidation validation = new UserLogin.LoginValidation(username, password, action);

            UserLogin.User user = new UserLogin.User();

            bool state = validation.ValidateUserInput(user);

            if (state)
            {
                StudentValidation studentValidation = new StudentValidation();

                if (studentValidation.GetStudentDataByUser(user) != null)
                {
                    Student student = studentValidation.GetStudentDataByUser(user);

                    loginInformation.ShowMainWindow();
                    loginInformation.FillAllFieldsForStudentMainWindow(student);
                    loginInformation.CloseLoginWindow();
                }
            }
        }

        public static void ReportError(String error)
        {
            MessageBox.Show("Login information is not valid, error: " + error);
        }
    }
}
