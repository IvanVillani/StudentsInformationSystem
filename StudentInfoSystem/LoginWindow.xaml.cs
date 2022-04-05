using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static MainWindow _mainWindow;
        public LoginWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnValidateLogin_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Password;

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

                    _mainWindow.Show();
                    _mainWindow.FillAllFieldsForStudent(student);
                    this.Close();
                }
            }
        }

        public static void ReportError(String error)
        {
            MessageBox.Show("Login information is not valid, error: " + error);
        }
    }
}
