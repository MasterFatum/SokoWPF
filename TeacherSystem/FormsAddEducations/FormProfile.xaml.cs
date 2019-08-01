﻿using System;
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

namespace TeacherSystem.FormsAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormProfile.xaml
    /// </summary>
    public partial class FormProfile : Window
    {

        public FormProfile(int id, string lastname, string firstname, string middlename, string position, string email)
        {
            InitializeComponent();

            TxbxUserId.Text = id.ToString();
            TxbxLastname.Text = lastname;
            TxbxFirstname.Text = firstname;
            TxbxMiddlename.Text = middlename;
            TxbxPosition.Text = position;
            TxbxEmail.Text = email;
        }

        UserRepository userRepository = new UserRepository();

        private void BtnChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            if (BtnChangeProfile.Content.ToString() == "Изменить")
            {
                BtnChangeProfile.Content = "Сохранить";
                TxbxLastname.IsEnabled = true;
                TxbxFirstname.IsEnabled = true;
                TxbxMiddlename.IsEnabled = true;
                TxbxPosition.IsEnabled = true;
                TxbxEmail.IsEnabled = true;
            }
            else if (BtnChangeProfile.Content.ToString() == "Сохранить")
            {
                BtnChangeProfile.Content = "Изменить";
                TxbxLastname.IsEnabled = false;
                TxbxFirstname.IsEnabled = false;
                TxbxMiddlename.IsEnabled = false;
                TxbxPosition.IsEnabled = false;
                TxbxEmail.IsEnabled = false;

                userRepository.EditUser(Convert.ToInt32(TxbxUserId.Text), 
                    TxbxLastname.Text.Trim(), 
                    TxbxFirstname.Text.Trim(), 
                    TxbxMiddlename.Text.Trim(), 
                    TxbxPosition.Text.Trim(), TxbxEmail.Text.Trim());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
