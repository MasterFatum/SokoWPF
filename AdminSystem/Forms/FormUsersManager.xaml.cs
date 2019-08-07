using System;
using System.Windows;
using System.Windows.Controls;
using BLL.Concrete;
using BLL.Entities;

namespace AdminSystem.Forms
{

    public partial class FormUsersManager : Window
    {
        UserRepository userRepository = new UserRepository();

        public int UserId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public FormUsersManager()
        {
            InitializeComponent();

            DataGridAllUsers.ItemsSource = userRepository.GetAllUser();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnUpdateListUsers_Click(object sender, RoutedEventArgs e)
        {
            userRepository.GetAllUser();
        }

        private void DataGridAllUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var users = DataGridAllUsers.CurrentItem as Users;

                if (users == null)
                {
                    return;
                }

                TxbxUserId.Text = users.Id.ToString();
                TxbxLastname.Text = users.Lastname;
                TxbxFirstname.Text = users.Firstname;
                TxbxMiddlename.Text = users.Middlename;
                TxbxPosition.Text = users.Position;
                TxbxEmail.Text = users.Email;
                TxbxPassword.Text = users.Password;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (TxbxUserId.Text != String.Empty)
            {
                if (TxBlChangeUser.Text == " Изменить")
                {
                    TxbxLastname.IsEnabled = true;
                    TxbxFirstname.IsEnabled = true;
                    TxbxMiddlename.IsEnabled = true;
                    TxbxPosition.IsEnabled = true;
                    TxbxEmail.IsEnabled = true;
                    TxbxPassword.IsEnabled = true;

                    TxBlChangeUser.Text = " Сохранить";
                }
                else if (TxBlChangeUser.Text == " Сохранить")
                {
                    TxbxLastname.IsEnabled = false;
                    TxbxFirstname.IsEnabled = false;
                    TxbxMiddlename.IsEnabled = false;
                    TxbxPosition.IsEnabled = false;
                    TxbxEmail.IsEnabled = false;
                    TxbxPassword.IsEnabled = false;

                    TxBlChangeUser.Text = " Изменить";

                    userRepository.EditUser(Convert.ToInt32(TxbxUserId.Text), TxbxLastname.Text.Trim(),
                        TxbxFirstname.Text.Trim(), TxbxMiddlename.Text.Trim(), TxbxPosition.Text.Trim(),
                        TxbxEmail.Text.Trim(), TxbxPassword.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("Не выбран пользователь для изменения!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данного пользователя?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                userRepository.DeleteUser(Convert.ToInt32(TxbxUserId.Text));
            }
        }
    }
}
