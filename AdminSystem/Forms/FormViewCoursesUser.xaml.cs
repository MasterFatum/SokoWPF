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
    /// <summary>
    /// Логика взаимодействия для FormViewCoursesUser.xaml
    /// </summary>
    public partial class FormViewCoursesUser : Window
    {
        public int Id { get; set; }

        CourseRepository courseRepository = new CourseRepository();


        public FormViewCoursesUser(int id, string lastname, string firstname, string middlename)
        {
            InitializeComponent();

            Id = id;

            LblUsername.Content = String.Format($"{lastname} {firstname} {middlename}");

            DataGridUserCourses.ItemsSource = courseRepository.GetCoursesByUserId(Id);
        }

        private void DataGridUserCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
