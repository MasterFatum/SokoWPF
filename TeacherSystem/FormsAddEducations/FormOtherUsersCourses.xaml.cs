using System;
using System.Windows;
using System.Windows.Controls;
using Bll.Concrete;
using BLL.Concrete;

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
            try
            {
                if (CbxOtherUsersCourses.SelectedIndex != -1)
                {
                    String usernameFio = CbxOtherUsersCourses.SelectedItem.ToString();

                    String[] words = usernameFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    DataGridOtherUsersCategory.ItemsSource = courseRepository.GetCoursesByFio(words[0], words[1], words[2], ((ComboBoxItem)CbxOtherUsersCategory.SelectedItem).Content.ToString());
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
    }
}
