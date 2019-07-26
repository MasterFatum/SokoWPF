﻿using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeacherSystem.Concrete;
using TeacherSystem.FormAddEducations;

namespace TeacherSystem
{
    public partial class MainWindow : Window
    {

        ContestsRepository contestsRepository = new ContestsRepository();

        SokoContext sokoContext = new SokoContext();


        public MainWindow(Users user)
        {
            InitializeComponent();

            TxbxUserId.Text = user.Id.ToString();
            TxbxUserLastname.Text = user.Lastname;
            TxbxUserFirstname.Text= user.Firstname;
            TxbxUserMiddlename.Text = user.Middlename;
            TxbxUserPosition.Text = user.Position;

            ArrayList items = new OtherRepository().GetAllCategoryByUserId(user.Id);

            DataGridMain.ItemsSource = items;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        private void BtnMainExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMainCategoryShow_Click(object sender, RoutedEventArgs e)
        {
            switch (((ComboBoxItem) CbxMainShowCategory.SelectedItem).Content.ToString())
            {
                case "Конкурсы":
                    IEnumerable<Contests> contestses = new ContestsRepository().GetContestsByUserId(Convert.ToInt32(TxbxUserId.Text));
                    DataGridMain.ItemsSource = contestses.ToList();
                    break;
                case "Курсы":
                    IEnumerable<Courses> courseses = new CoursesRepository().GetCoursesByUserId((Convert.ToInt32(TxbxUserId.Text)));
                    DataGridMain.ItemsSource = courseses.ToList();
                    break;
            }
        }

        private void BtnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            new FormChooseEducation(Convert.ToInt32(TxbxUserId.Text)).ShowDialog();
        }

        private void BtnMainUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList items = new OtherRepository().GetAllCategoryByUserId(Convert.ToInt32(TxbxUserId.Text));
                DataGridMain.ItemsSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void DataGridMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)CbxMainShowCategory.SelectedItem).Content.ToString() == "Конкурсы")
            {
                var items = DataGridMain.CurrentItem as Contests;

                if (items == null)
                {
                    return;
                }

                Id = items.Id;
                UserId = items.UserId;
                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
            }
            if (((ComboBoxItem)CbxMainShowCategory.SelectedItem).Content.ToString() == "Курсы")
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
            }

        }

        private void BtnMainDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данную запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                contestsRepository.DeleteContests(Id, UserId);
            }
           
        }

        private void BtnMainEdit_Click(object sender, RoutedEventArgs e)
        {
            new FormEdit(Id, UserId, Category, Title, Description).ShowDialog();
        }
    }
}
