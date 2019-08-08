﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using BLL.Concrete;
using BLL.Entities;


namespace TeacherSystem
{

    public partial class Registrations : Window
    {
        public Registrations()
        {
            InitializeComponent();
            TxbxFirstname.TextChanged += TxbxLastname_TextChanged;
            TxbxLastname.TextChanged += TxbxLastname_TextChanged;
            TxbxMiddlename.TextChanged += TxbxLastname_TextChanged;
        }
        
        UserRepository userRepository = new UserRepository();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbxLastname.Text == String.Empty || 
                    TxbxFirstname.Text == String.Empty || 
                    TxbxMiddlename.Text == String.Empty || 
                    TxbxEmail.Text == String.Empty || 
                    PwdBox.Password == String.Empty)
                {
                    
                    MessageBox.Show("Одно или несколько полей не заполнено!");
                }
                else
                {
                    if (PwdBox.Password != String.Empty && PwdBox.Password.Equals(PwdBoxReplase.Password))
                    {
                        Users user = new Users();
                        user.Lastname = TxbxLastname.Text.Trim();
                        user.Firstname = TxbxFirstname.Text.Trim();
                        user.Middlename = TxbxMiddlename.Text.Trim();
                        user.Position = ((ComboBoxItem)CbxPosition.SelectedItem).Content.ToString();
                        user.Privilege = "User";
                        user.Email = TxbxEmail.Text.Trim();
                        user.Password = PwdBox.Password;
                        user.Date = String.Format(
                            $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");

                        userRepository.AddUser(user);

                        BtnClear_Click(null, null);
                        BtnClose_Click(null, null);
                    }

                    else
                    {
                        MessageBox.Show("Пароли не совпадают!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxLastname.Text = String.Empty;
            TxbxFirstname.Text = String.Empty;
            TxbxMiddlename.Text = String.Empty;
            TxbxEmail.Text = String.Empty;
            PwdBox.Password = String.Empty;
            PwdBoxReplase.Password = String.Empty;
            CbxPosition.SelectedIndex = -1;
        }

        void FirstCharToUpper(TextBox textBox)
        {
            if (textBox.Text.Length == 1)
                textBox.Text = textBox.Text.ToUpper();
            textBox.Select(textBox.Text.Length, 0);
        }

        private void TxbxLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstCharToUpper((TextBox)sender);
        }
    }
}
