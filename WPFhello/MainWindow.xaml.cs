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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new();
            ListBoxItem david = new();

            james.Content = "James";
            david.Content = "David";

            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Entered name should contain at least 2 symbols!!!");
            } else
            {
                MessageBox.Show("Hi " + txtName.Text + "!!!\n" + 
                    "This is my first program on MS VS 2022!!!");
            }
        }

        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            if (txtN.Text.Length < 1 || txtY.Text.Length < 1)
            {
                MessageBox.Show("N and/or Y are/is not entered!");
            }
            else
            {
                try
                {
                    Double n = Double.Parse(txtN.Text);
                    Double y = Double.Parse(txtY.Text);

                    Double res = Math.Pow(n, y);

                    MessageBox.Show("Result: " + res);

                } catch (Exception)
                {
                    MessageBox.Show("N and/or Y sre/is not valid!");
                }
            }
        }

        private void btnFact_Click(object sender, RoutedEventArgs e)
        {
            if (txtN.Text.Length < 1)
            {
                MessageBox.Show("N is not entered!");
            }
            else
            {
                try
                {
                    Int32 n = Int32.Parse(txtN.Text);

                    Int64 res = 1;

                    for (int i = 1; i <= n; i++)
                    {
                        res *= i;
                    }

                    MessageBox.Show("Result: " + res);

                }
                catch (Exception)
                {
                    MessageBox.Show("N is not valid!");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Are you sure you want to exit?", "Ops!", MessageBoxButton.YesNo);
            if (msgBoxResult == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else if (msgBoxResult == MessageBoxResult.No)
            {
                e.Cancel= true;
            }
        }

        private void btnShowSelectedPerson_Click(object sender, RoutedEventArgs e)
        {
            MyMessage myMsgWindow = new MyMessage();
            myMsgWindow.Show();

            // string greetingMsg;
            // greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            // MessageBox.Show("Hi " + greetingMsg);
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
