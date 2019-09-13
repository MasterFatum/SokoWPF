using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using AdminSystem.Forms;
using BLL.Concrete;
using BLL.Entities;

namespace AdminSystem
{
    public partial class MainWindow
    {
        UserRepository userRepository = new UserRepository();

        public string User { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public new string Title { get; set; }
        public string Description { get; set; }
        public int? Evaluation { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public MainWindow(Users user)
        {
            InitializeComponent();

            User = user.Lastname;

            DataGridAllUsers.ItemsSource = userRepository.GetAllUser();

            LblAllUsers.Content = userRepository.GetAllUsersCount();
        }

        private void BtnMainExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new OtherRepository().SettingDataGridAdmins(DataGridAllUsers);
        }

        private void DataGridAllUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var items = DataGridAllUsers.CurrentItem as Users;

                if (items == null)
                {
                    return;
                }

                Id = items.Id;
                Lastname = items.Lastname;
                Firstname = items.Firstname;
                Middlename = items.Middlename;

                new FormViewCoursesUser(Id, Lastname, Firstname, Middlename, User).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMainUsersManage_Click(object sender, RoutedEventArgs e)
        {
            new FormUsersManager(User).ShowDialog();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(DataGridAllUsers.ItemsSource);

            if (TxbxSearch.Text.Trim() == String.Empty)
            {
                viewSource.Filter = null;
            }
            else
            {
                viewSource.Filter = o =>
                {
                    Users u = o as Users;

                    return u.Lastname.ToString().Contains(TxbxSearch.Text.Trim());

                    
                };
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataGridAllUsers.ItemsSource = new UserRepository().GetAllUser();
            TxbxSearch.Text = String.Empty;

            new OtherRepository().SettingDataGridAdmins(DataGridAllUsers);
        }
    }
}
