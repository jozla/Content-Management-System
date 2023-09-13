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
using static System.Net.Mime.MediaTypeNames;

namespace Projekat_HCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            emailTextBox.Text = "email@address.com";           
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void emailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text.Equals("email@address.com"))
            {
                emailTextBox.Text = "";
            }
            emailTextBox.Background = Brushes.LightGray;
        }
        private void emailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text.Trim().Equals(string.Empty))
            {
                emailTextBox.Text = "email@address.com";
            }
            emailTextBox.Background = Brushes.White;
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Background = Brushes.LightGray;
        }

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {             
                passwordTextBox.Background = Brushes.White;
            
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                if (emailTextBox.Text.Trim().Equals("admin@gmail.com"))
                {
                    Indicator.isAdmin = true;
                }
                else
                {
                    Indicator.isAdmin = false;
                }
                AdminUserWindow adw = new AdminUserWindow();
                this.Close();
                adw.ShowDialog();
            }
        }

        public bool validate()
        {
            if ((emailTextBox.Text.Trim().Equals("") || emailTextBox.Text.Trim().Equals("email@address.com")) && passwordTextBox.Password.ToString().Trim().Equals(""))
            {
                errorLabel.Content = "Please enter email address and \npassword.";
                return false;
            }
            else if (emailTextBox.Text.Trim().Equals("") || emailTextBox.Text.Trim().Equals("email@address.com"))
            {
                errorLabel.Content = "Please enter email address.";
                return false;
            }
            else if (passwordTextBox.Password.ToString().Trim().Equals(""))
            {
                errorLabel.Content = "Please enter password.";
                return false;
            }
            else if ((!(emailTextBox.Text.Trim().Equals("admin@gmail.com") && passwordTextBox.Password.ToString().Trim().Equals("admin123")))
                    && (!(emailTextBox.Text.Trim().Equals("user@gmail.com") && passwordTextBox.Password.ToString().Trim().Equals("user123")))
                )
            {
                errorLabel.Content = "Invalid email or password.";
                return false;
            }
            else
            {               
                return true;
            }           
        }
    }
}
