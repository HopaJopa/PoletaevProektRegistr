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

namespace ПолетаевПроектт
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            int b = 0;
            var email = emailbox.Text;
            var login = loginbox.Text;
            var password = passww1.Text;
            var context = new AppDbContext();

            if (emailbox.Text.Contains("@"))
            {
                b += 1;
            }
            if (b == 0)
            {
                vyvod.Text = "Вы ввели почту неверно!";
                emailbox.Foreground = Brushes.Red;
                return;
            }
            else
            {
                emailbox.Foreground = Brushes.Black;
            }

            if (passw.Text.Contains("!") || RetryPassww1.Text.Contains("!"))
                {
                    a += 1;
                }
                if (passw.Text.Contains("@") || RetryPassww1.Text.Contains("@"))
            {
                    a += 1;
                }
                if (passw.Text.Contains("$") || RetryPassww1.Text.Contains("$"))
            {
                    a += 1;
                }
                if (passw.Text.Contains("%") || RetryPassww1.Text.Contains("%"))
            {
                    a += 1;
                }
                if (passw.Text.Contains("/") || RetryPassww1.Text.Contains("/"))
            {
                    a += 1;
                }
                if (passw.Text.Contains("?") || RetryPassww1.Text.Contains("?"))
            {
                    a += 1;
                }
                if (passw.Text.Contains("&") || RetryPassww1.Text.Contains("&"))
                {
                    a += 1;
                }
                if (a == 0)
                {
                    vyvod.Text = "Пароль должен содержать\n специальный символ!";
                    passw.Foreground = Brushes.Red;
                    passw1.Foreground = Brushes.Red;
                    RetryPassw.Foreground = Brushes.Red;
                    RetryPassww1.Foreground = Brushes.Red;
                    return;
                }

            if (passww1.Text.Length < 5)
            {
                passw.Foreground = Brushes.Red;
                passw1.Foreground = Brushes.Red;
                RetryPassw.Foreground = Brushes.Red;
                RetryPassww1.Foreground = Brushes.Red;
                vyvod.Text = "Пароль должен содержать 5\n или более символов";
                return;
            }
            else
            {
                passw.Foreground = Brushes.Black;
                passw1.Foreground = Brushes.Black;
                RetryPassw.Foreground = Brushes.Black;
                RetryPassww1.Foreground = Brushes.Black;
            }

            var user_input2 = context.Users.FirstOrDefault(x => x.email == email);
            if (user_input2 != null)
            {
                vyvod.Text = "Такой пользователь уже существует";
                loginbox.Foreground = Brushes.Red;
                return;
            }
            else
            {
                loginbox.Foreground = Brushes.Black;
            }

            var user_input = context.Users.FirstOrDefault(x => x.login == login);
            if (user_input != null)
            {
                vyvod.Text = "Такой пользователь уже существует";
                emailbox.Foreground = Brushes.Red;
                loginbox.Foreground = Brushes.Red;
                return;
            }
            else
            {
                emailbox.Foreground = Brushes.Black;
                loginbox.Foreground = Brushes.Black;
            }


            if (passww1.Text == RetryPassww1.Text)
            {
                var user = new User { login = login, password = password, email = email};
                context.Users.Add(user);
                context.SaveChanges();
                vyvod.Text = "Вы успешно зарегистрировались!";
            }
            if (passww1.Text != RetryPassww1.Text)
            {
                vyvod.Text = "Пароли не совпадают!";
                passw.Foreground = Brushes.Red;
                passw1.Foreground = Brushes.Red;
                RetryPassw.Foreground = Brushes.Red;
                RetryPassww1.Foreground = Brushes.Red;
                return;
            }
            else
            {
                passw.Foreground = Brushes.Black;
                passw1.Foreground = Brushes.Black;
                RetryPassw.Foreground = Brushes.Black;
                RetryPassww1.Foreground = Brushes.Black;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
        }


        private void cb_Click(object sender, RoutedEventArgs e)
        {
            var cbb = sender as CheckBox;
            if (cbb.IsChecked.Value)
            {
                passww1.Text = passw1.Password.ToString();
                passww1.Visibility = Visibility.Visible;

                RetryPassww1.Text = RetryPassw.Password.ToString();
                RetryPassww1.Visibility = Visibility.Visible;
            }
            else
            {
                passw1.Password = passww1.Text;
                passww1.Visibility = Visibility.Hidden;

                RetryPassw.Password = passww1.Text;
                RetryPassww1.Visibility = Visibility.Hidden;
            }
        }
    }
}
