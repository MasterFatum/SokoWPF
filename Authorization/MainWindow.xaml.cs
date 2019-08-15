using System;
using System.Windows;
using System.Windows.Controls;
using BLL.Concrete;
using BLL.Entities;

namespace Authorization
{
    public partial class MainWindow : Window
    {
        UserRepository userRepository = new UserRepository();
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private const string ConnectionStringInside = "data source=NETSCHOOL;initial catalog=SOKO;integrated security=False;User ID=SOKOUser;Password=Admin;MultipleActiveResultSets=True;App=EntityFramework";
        private const string ConnectionStringOutside = "data source=87.229.192.199,1435;initial catalog=SOKO;integrated security=False;User ID=SOKOUser;Password=Admin;MultipleActiveResultSets=True;App=EntityFramework";
        

        private void BtnAuthorizeExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new Registrations().ShowDialog();
        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            
            switch (((ComboBoxItem)CbxAuthorizeAs.SelectedItem).Content.ToString())
            {
                //АВТОРИЗАЦИЯ ПОЛЬЗОВАТЕЛЯ
                case "Учитель":
                    Users user = userRepository.ValidationUser(TxbxLogin.Text.Trim(), TxbxPassword.Password);

                    if (user != null)
                    {
                        if (ChkBoxSaveUser.IsChecked == true)
                        {
                            Properties.Settings.Default.Username = TxbxLogin.Text.Trim();
                            Properties.Settings.Default.Password = TxbxPassword.Password.Trim();
                            Properties.Settings.Default.IsSaveUser = ChkBoxSaveUser.IsChecked == true;

                            Properties.Settings.Default.Save();
                        }
                        if (ChkBoxSaveUser.IsChecked == false)
                        {
                            Properties.Settings.Default.Username = String.Empty;
                            Properties.Settings.Default.Password = String.Empty;
                            Properties.Settings.Default.IsSaveUser = ChkBoxSaveUser.IsChecked== false;

                            Properties.Settings.Default.Save();
                        }

                        Visibility = Visibility.Collapsed;
                        Visibility = Visibility.Hidden;
                        
                        new Authorization.MainWindow(user).ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!", "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    break;

                //АВТОРИЗАЦИЯ АДМИНИСТРАТОРА
                case "Администратор":
                    Users userAdmin = userRepository.ValidationAdmin(TxbxLogin.Text.Trim(), TxbxPassword.Password);

                    if (userAdmin != null)
                    {
                        if (ChkBoxSaveUser.IsChecked == true)
                        {
                            //Properties.Settings.Default.Username = TxbxLogin.Text.Trim();
                            //Properties.Settings.Default.Password = TxbxPassword.Password.Trim();
                            //Properties.Settings.Default.IsSaveUser = ChkBoxSaveUser.IsChecked.Value;

                            //Properties.Settings.Default.Save();
                        }

                        this.Visibility = Visibility.Collapsed;
                        this.Visibility = Visibility.Hidden;
                        new AdminSystem.MainWindow().ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!", "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    break;
            }
        }

        private void ChkBoxSaveUser_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void AuthorizeForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                Application.Current.Shutdown();
            }
        }

        private void CbxSetConnectionString_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbxSetConnectionString.SelectedIndex == 0)
            {
                new OtherRepository().SetConnectionString(ConnectionStringInside);
            }
            else if (CbxSetConnectionString.SelectedIndex == 1)
            {
                new OtherRepository().SetConnectionString(ConnectionStringOutside);
            }
            
        }
    }
}
