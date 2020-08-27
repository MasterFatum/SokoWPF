﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Bll.Concrete;
using BLL.Concrete;
using BLL.Entities;
using UserSystem.FormsAddEducations;

namespace TeacherSystem
{
    public partial class MainWindow
    {
        CourseRepository courseRepository = new CourseRepository();
        OtherRepository otherRepository = new OtherRepository();
        FtpRepository ftpRepository = new FtpRepository();

        public MainWindow(Users user)
        {
            InitializeComponent();

            DataGridMain.ItemsSource = courseRepository.GetCoursesByUserId(user.Id);

            TxbxAllRating.Text = courseRepository.AllRating(user.Id);

            CbxMainShowCategory.SelectedIndex = -1;

            TxbxUserId.Text = user.Id.ToString();
            TxbxUserLastname.Text = user.Lastname;
            TxbxUserFirstname.Text = user.Firstname;
            TxbxUserMiddlename.Text = user.Middlename;
            TxbxUserPosition.Text = user.Position;
            Email = user.Email;

        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            otherRepository.SettingDataGridUsers(DataGridMain);
        }

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
        public string Date { get; set; }
        public string Hyperlink { get; set; }
        public string FileName { get; set; }

        private void BtnMainExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            new FormChooseCategory(Convert.ToInt32(TxbxUserId.Text)).ShowDialog();
        }

        private void BtnMainUpdate_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Courses> allCourseses = courseRepository.GetCoursesByUserId(Convert.ToInt32(TxbxUserId.Text));
            DataGridMain.ItemsSource = allCourseses;
            CbxMainShowCategory.SelectedIndex = -1;
            otherRepository.SettingDataGridUsers(DataGridMain);
        }

        private void DataGridMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var items = DataGridMain.CurrentItem as Courses;

                if (items == null)
                {
                        return;
                }

                Id = items.Id;
                UserId = items.UserId;
                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
                Evaluation = items.Evaluation;
                Hyperlink = items.Hyperlink;
                FileName = items.FileName;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMainDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данную запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                courseRepository.DeleteCourse(Id, UserId);

                if (!String.IsNullOrEmpty(FileName))
                {
                    ftpRepository.DeleteFile(UserId.ToString(), FileName);
                }
                
                BtnMainUpdate_Click(null, null);
            }
        }

        private void BtnMainEdit_Click(object sender, RoutedEventArgs e)
        {
            new FormEdit(Id, UserId, Category, Title, Description, Hyperlink, FileName).ShowDialog();
        }

        private void CbxMainShowCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbxMainShowCategory.SelectedIndex != -1)
            {
                DataGridMain.ItemsSource = courseRepository.GetCoursesByCategory(Convert.ToInt32(TxbxUserId.Text), (((ComboBoxItem)CbxMainShowCategory.SelectedItem).Content.ToString()));

                new OtherRepository().SettingDataGridUsers(DataGridMain);
            }
        }

        private void BtnMainOtherUsersCourses_Click(object sender, RoutedEventArgs e)
        {
            new FormOtherUsersCourses().ShowDialog();
        }

        private void DataGridMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var items = DataGridMain.CurrentItem as Courses;

                if (items == null)
                {
                    return;
                }

                UserId = items.UserId;
                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
                Evaluation = items.Evaluation ?? 0;
                Date = items.Date ?? "Дата отсутствует";
                Hyperlink = items.Hyperlink;
                FileName = items.FileName;

                new FormViewItemsFull(UserId, "Вы", Category, Title, Description, Date, Hyperlink, FileName, Evaluation.Value).ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new FormProfile(Convert.ToInt32(TxbxUserId.Text), 
                TxbxUserLastname.Text, TxbxUserFirstname.Text, 
                TxbxUserMiddlename.Text, TxbxUserPosition.Text, Email).ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                Application.Current.Shutdown();
            }
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new FormInfo().ShowDialog();
        }

        readonly SolidColorBrush orange = new SolidColorBrush(Colors.Orange);
        SolidColorBrush white = new SolidColorBrush(Colors.White);
        SolidColorBrush green = new SolidColorBrush(Colors.Green);

        private void DataGridMain_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Courses courses = (Courses)e.Row.DataContext;

            if (courses.Evaluation == null)
            {
                e.Row.Background = orange;
            }
            if (courses.Evaluation != null && courses.DateEdit == null)
            {
                e.Row.Background = white;
            }
            if (courses.Evaluation != null && courses.DateEdit != null)
            {
                e.Row.Background = green;
            }
        }
        
    }
}
