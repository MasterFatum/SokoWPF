using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using BLL.Concrete;
using BLL.Entities;

namespace AdminSystem.Forms
{

    public partial class FormUsersManager
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new OtherRepository().SettingDataGridAdmins(DataGridAllUsers);
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

                TxbxLastname.IsEnabled = false;
                TxbxFirstname.IsEnabled = false;
                TxbxMiddlename.IsEnabled = false;
                TxbxPosition.IsEnabled = false;
                TxbxEmail.IsEnabled = false;
                TxbxPassword.IsEnabled = false;
                CbxPrivilege.IsEnabled = false;

                TxBlChangeUser.Text = " Изменить";

                TxbxUserId.Text = users.Id.ToString();
                TxbxLastname.Text = users.Lastname;
                TxbxFirstname.Text = users.Firstname;
                TxbxMiddlename.Text = users.Middlename;
                TxbxPosition.Text = users.Position;
                TxbxEmail.Text = users.Email;
                TxbxPassword.Text = users.Password;
                TxbxDate.Text = users.Date;
                

                if (users.Privilege == "User")
                {
                    CbxPrivilege.Items.Clear();
                    CbxPrivilege.Items.Add("User");
                    CbxPrivilege.Items.Add("Admin");
                    CbxPrivilege.SelectedIndex = 0;
                }
                if (users.Privilege == "Admin")
                {
                    CbxPrivilege.Items.Clear();
                    CbxPrivilege.Items.Add("Admin");
                    CbxPrivilege.Items.Add("User");
                    CbxPrivilege.SelectedIndex = 0;
                }

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
                    CbxPrivilege.IsEnabled = true;

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
                    CbxPrivilege.IsEnabled = false;

                    TxBlChangeUser.Text = " Изменить";

                    userRepository.EditUser(Convert.ToInt32(TxbxUserId.Text), TxbxLastname.Text.Trim(),
                        TxbxFirstname.Text.Trim(), TxbxMiddlename.Text.Trim(), TxbxPosition.Text.Trim(),
                        TxbxEmail.Text.Trim(), TxbxPassword.Text.Trim(), CbxPrivilege.SelectedItem.ToString());
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

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (TxBlAddUser.Text == " Добавить")
            {
                TxbxLastname.IsEnabled = true;
                TxbxFirstname.IsEnabled = true;
                TxbxMiddlename.IsEnabled = true;
                TxbxPosition.IsEnabled = true;
                TxbxEmail.IsEnabled = true;
                TxbxPassword.IsEnabled = true;
                CbxPrivilege.IsEnabled = true;

                TxBlChangeUser.Text = " Изменить";

                TxbxUserId.Text = String.Empty;
                TxbxLastname.Text = String.Empty;
                TxbxFirstname.Text = String.Empty;
                TxbxMiddlename.Text = String.Empty;
                TxbxPosition.Text = String.Empty;
                TxbxEmail.Text = String.Empty;
                TxbxPassword.Text = String.Empty;
                TxbxDate.Text = String.Format($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");

                CbxPrivilege.Items.Clear();
                CbxPrivilege.Items.Add("Admin");
                CbxPrivilege.Items.Add("User");

                TxBlAddUser.Text = " Сохранить";
            }
            else if (TxBlAddUser.Text == " Сохранить")
            {
                TxbxLastname.IsEnabled = false;
                TxbxFirstname.IsEnabled = false;
                TxbxMiddlename.IsEnabled = false;
                TxbxPosition.IsEnabled = false;
                TxbxEmail.IsEnabled = false;
                TxbxPassword.IsEnabled = false;
                CbxPrivilege.IsEnabled = false;

                CbxPrivilege.Items.Clear();

                TxBlAddUser.Text = " Добавить";

            }
        }
    }
}
