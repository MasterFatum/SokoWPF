using System;
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
using Bll.Concrete;
using BLL.Entities;

namespace AdminSystem.Forms
{
    
    public partial class FormViewCoursesUser : Window
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Lastname { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Evaluation { get; set; }

        CourseRepository courseRepository = new CourseRepository();


        public FormViewCoursesUser(int id, string lastname, string firstname, string middlename)
        {
            InitializeComponent();

            Id = id;

            LblUserId.Content = Id;

            Lastname = lastname;

            LblUsername.Content = String.Format($"{lastname} {firstname} {middlename}");

            DataGridUserCourses.ItemsSource = courseRepository.GetCoursesByUserId(Id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnShowOtherUsersCourses_Click(object sender, RoutedEventArgs e)
        {
            DataGridUserCourses.ItemsSource =
                courseRepository.GetCoursesByCategory(Id, ((ComboBoxItem)CbxUserCategory.SelectedItem).Content.ToString());
        }

        private void DataGridUserCourses_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var items = DataGridUserCourses.CurrentItem as Courses;

                if (items == null)
                {
                    return;
                }

                UserId = items.UserId;
                Id = items.Id;
                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
                Evaluation = items.Evaluation ?? 0;

                new FormViewCourseFull(UserId, Id, Lastname, Category, Title, Description, Evaluation.Value).ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataGridUserCourses.ItemsSource = courseRepository.GetCoursesByUserId(Convert.ToInt32(LblUserId.Content)).ToList();
        }
    }
}
