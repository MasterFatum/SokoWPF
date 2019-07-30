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
using TeacherSystem.Concrete;

namespace TeacherSystem
{
    public partial class Authorization : Window
    {
        UserRepository userRepository = new UserRepository();

        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnAuthorizeExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new Registrations().ShowDialog();
        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            Users user = userRepository.ValidationUser(TxbxLogin.Text.Trim(), TxbxPassword.Password);

            if (user != null)
            {
                if (ChkBoxSaveUser.IsChecked == true)
                {
                    Properties.Settings.Default.Username = TxbxLogin.Text.Trim();
                    Properties.Settings.Default.Password = TxbxPassword.Password.Trim();
                    Properties.Settings.Default.IsSaveUser = ChkBoxSaveUser.IsChecked.Value;

                    Properties.Settings.Default.Save();
                }

                this.Visibility = Visibility.Collapsed;
                this.Visibility = Visibility.Hidden;
                new MainWindow(user).ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ChkBoxSaveUser_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
