using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class LoginInformation : INotifyPropertyChanged
    {
        string _username = "";
        string _password = "";

        LoginCommand _loginCommand = new LoginCommand();

        public delegate void MyDelegate();

        private static MyDelegate _delegate;

        private static MainWindow _mainWindow;

        public LoginCommand LoginInfoCommand
        {
            get { return _loginCommand; }
        }
        public LoginInformation(MainWindow mainWindow, MyDelegate myDelegate)
        {
            _mainWindow = mainWindow;
            _delegate = myDelegate;
        }
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");

                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void ShowMainWindow()
        {
            _mainWindow.Show();
        }

        public void CloseMainWindow()
        {
            _mainWindow.Close();
        }

        public void CloseLoginWindow()
        {
            _delegate.Invoke();
        }

        public void FillAllFieldsForStudentMainWindow(Student student)
        {
            _mainWindow.FillAllFieldsForStudent(student);
        }
    }
}
