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
using TeacherSystem.Concrete;

namespace TeacherSystem.FormsAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormOtherUsersCourses.xaml
    /// </summary>
    public partial class FormOtherUsersCourses : Window
    {
        public FormOtherUsersCourses()
        {
            InitializeComponent();
        }

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
            String usernameFio = CbxOtherUsersCourses.SelectedItem.ToString();

            String[] words = usernameFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            DataGridOtherUsersCategory.ItemsSource = courseRepository.GetCoursesByFio(words[0], words[1], words[2], ((ComboBoxItem)CbxOtherUsersCategory.SelectedItem).Content.ToString());
        }
    }
}
