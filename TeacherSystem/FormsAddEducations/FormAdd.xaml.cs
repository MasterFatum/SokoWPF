using System;
using System.Windows;
using Bll.Concrete;
using BLL.Entities;


namespace TeacherSystem.FormsAddEducations
{
    public partial class FormAdd : Window
    {
        CourseRepository courseRepository = new CourseRepository();

        public string SelectedCategory { get; set; }
        public int UserIdAdd { get; set; }

        public FormAdd(int userId, string selectedCategory)
        {
            InitializeComponent();

            SelectedCategory = selectedCategory;
            TxbxSelectedCategory.Text = SelectedCategory;
            UserIdAdd = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxTitle.Text = String.Empty;
            TxbxDescription.Text = String.Empty;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbxTitle.Text != String.Empty && TxbxDescription.Text != String.Empty)
            {
                Courses courses = new Courses
                {
                    UserId = UserIdAdd,
                    Category = SelectedCategory,
                    Title = TxbxTitle.Text.Trim(),
                    Description = TxbxDescription.Text.Trim(),
                    Date = String.Format($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}")
                };
                courseRepository.AddCourse(courses);
            }
            else
            {
                MessageBox.Show("Одно или несколько полей не заполнено!", "", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            
        }
    }
}
