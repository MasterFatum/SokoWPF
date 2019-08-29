﻿using System;
using System.Windows;
using System.Windows.Controls;
using Bll.Concrete;
using BLL.Concrete;
using BLL.Entities;

namespace UserSystem.FormsAddEducations
{
    public partial class FormOtherUsersCourses : Window
    {
        public FormOtherUsersCourses()
        {
            InitializeComponent();
        }

        public string Lastname { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Evaluation { get; set; }
        public string Date { get; set; }
        public string Hyperlink { get; set; }

        CourseRepository courseRepository = new CourseRepository();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxOtherUsersCourses.ItemsSource = new UserRepository().GetFioUsers();
        }

        private void BtnShowOtherUsersCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CbxOtherUsersCourses.SelectedIndex != -1)
                {

                    //АНАЛИЗИРУЕМ COMBOBOX

                    if (CbxOtherUsersCategory.SelectedIndex == 0)
                    {
                        String usernameFio = CbxOtherUsersCourses.SelectedItem.ToString();

                        String[] words = usernameFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        DataGridOtherUsersCategory.ItemsSource =
                            courseRepository.GetCoursesByFio(words[0], words[1], words[2]);

                        new OtherRepository().SettingDataGridUsers(DataGridOtherUsersCategory);
                    }
                    else if (CbxOtherUsersCategory.SelectedIndex != 0)
                    {
                        String usernameFio = CbxOtherUsersCourses.SelectedItem.ToString();

                        String[] words = usernameFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        DataGridOtherUsersCategory.ItemsSource = courseRepository.GetCoursesByFio(words[0], words[1], words[2], ((ComboBoxItem)CbxOtherUsersCategory.SelectedItem).Content.ToString());

                        new OtherRepository().SettingDataGridUsers(DataGridOtherUsersCategory);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Выберите пользователя!", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void DataGridOtherUsersCategory_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var items = DataGridOtherUsersCategory.CurrentItem as Courses;

                if (items == null)
                {
                    return;
                }

                Lastname = CbxOtherUsersCourses.SelectedItem.ToString();
                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
                Evaluation = items.Evaluation ?? 0;
                Date = items.Date ?? "Дата отсутствует";
                Hyperlink = items.Hyperlink;

                new FormViewItemsFull(Lastname, Category, Title, Description, Date, Hyperlink, Evaluation).ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
