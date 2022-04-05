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
    /// Interaction logic for TestDialogWindow.xaml
    /// </summary>
    public partial class TestDialogWindow : Window
    {
        private static MainWindow _mainWindow;
        public TestDialogWindow()
        {
            InitializeComponent();
            _mainWindow = new MainWindow();
        }

        private void btnTestModeEnabled_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnTestModeDisabled_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(_mainWindow);

            loginWindow.Show();
            this.Close();
        }
    }
}
