﻿using System.Windows;

namespace UserSystem.FormsAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormInfo.xaml
    /// </summary>
    public partial class FormInfo : Window
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
