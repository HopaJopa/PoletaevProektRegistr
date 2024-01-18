using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ПолетаевПроектт
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = loginbox.Text;
            var login = loginbox.Text;
            var password = passw.Password.ToString();
            var context = new AppDbContext();



            var user1 = context.Users.SingleOrDefault(x => x.login == login || x.email == email);
            if (user1 is null)
            {
                loginbox.Foreground = Brushes.Red;
                vyvod.Text = "Неправильный логин\n";
                return;
            }
            else
            {
                loginbox.Foreground = Brushes.Black;
            }


            var user2 = context.Users.SingleOrDefault(x => x.password == password);
            if (user2 is null)
            {
                passw.Foreground = Brushes.Red;
                vyvod.Text = "Неправильный пароль";
                return;
            }
            else
            {
                passw.Foreground = Brushes.Black;
            }

            vyvod.Text = "Вы успешно вошли в аккаунт!";
            this.Hide();
            Hello mainWindow = new Hello();
            mainWindow.Show();
            MessageBox.Show($"Здравствуйте, {loginbox.Text}!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void passw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passw.Password == "Password")
            {
                vyvod.Text = "Вы успешно вошли в аккаунт!";
                this.Hide();
                Hello mainWindow = new Hello();
                mainWindow.Show();
                MessageBox.Show($"Здравствуйте, {loginbox.Text}!");
            }
            else
            {
                passw.Foreground = Brushes.Red;
                vyvod.Text = "Неправильный пароль";
                return;
            }
        }

        private void VisiblePassw_Click(object sender, RoutedEventArgs e)
        {
            var cbb = sender as CheckBox;
            if (cbb.IsChecked.Value)
            {
                passw1.Text = passw.Password.ToString();
                passw1.Visibility = Visibility.Visible;
            }
            else
            {
                passw.Password = passw1.Text;
                passw1.Visibility = Visibility.Hidden;
            }
        }

    }
}
