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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Student information system";
            btnTestDataExit.Visibility = Visibility.Hidden;
        }

        public void ClearAllFields()
        {
            foreach(var control in personalInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.Text = String.Empty;
                }
            }

            foreach (var control in studentInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.Text = String.Empty;
                }
            }
        }

        public void FillAllFieldsForStudent(Student student)
        {
            txtFirstName.Text = student.firstName;
            txtSurname.Text = student.surname;
            txtLastName.Text = student.lastName;
            txtFaculty.Text =student.faculty;
            txtSpeciality.Text = student.speciality;
            txtDegree.Text = student.degree;
            txtStatus.Text = student.status;
            txtFakNumber.Text = student.fakNum;
            txtCourse.Text = student.course.ToString();
            txtStream.Text = student.stream.ToString();
            txtGroup.Text = student.group.ToString();
        }

        public void DisableAllInput()
        {
            foreach (var control in personalInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.IsEnabled = false;
                }
            }

            foreach (var control in studentInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.IsEnabled = false;
                }
            }
        }

        public void EnableAllInput()
        {
            foreach (var control in personalInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.IsEnabled = true;
                }
            }

            foreach (var control in studentInfoGrid.Children)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.IsEnabled = true;
                }
            }
        }

        private void btnTestData_Click(object sender, RoutedEventArgs e)
        {
            btnTestData.Visibility = Visibility.Hidden;
            btnTestDataExit.Visibility = Visibility.Visible;

            Student testStudent = StudentData.TestStudents[0];
            MessageBox.Show("Test Mode enabled!");

            EnableAllInput();
            FillAllFieldsForStudent(testStudent);
        }

        private void btnTestDataExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test Mode disabled!");

            ClearAllFields();
            DisableAllInput();

            btnTestDataExit.Visibility = Visibility.Hidden;
            btnTestData.Visibility = Visibility.Visible;
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(this);

            loginWindow.ShowDialog();
        }
    }
}
