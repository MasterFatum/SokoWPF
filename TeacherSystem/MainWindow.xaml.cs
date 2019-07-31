using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
using TeacherSystem.FormsAddEducations;

namespace TeacherSystem
{
    public partial class MainWindow : Window
    {
        CourseRepository courseRepository = new CourseRepository();
        OtherRepository otherRepository = new OtherRepository();

        public MainWindow(Users user)
        {
            InitializeComponent();

            DataGridMain.ItemsSource = courseRepository.GetCoursesByUserId(user.Id);

            CbxMainShowCategory.SelectedIndex = -1;

            TxbxUserId.Text = user.Id.ToString();
            TxbxUserLastname.Text = user.Lastname;
            TxbxUserFirstname.Text= user.Firstname;
            TxbxUserMiddlename.Text = user.Middlename;
            TxbxUserPosition.Text = user.Position;

        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Evaluation { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            otherRepository.SettingDataGrid(DataGridMain);
        }

        private void BtnMainExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMainCategoryShow_Click(object sender, RoutedEventArgs e)
        {
            if (CbxMainShowCategory.SelectedIndex != -1)
            {
                DataGridMain.ItemsSource = courseRepository.GetCoursesByCategory(Convert.ToInt32(TxbxUserId.Text), (((ComboBoxItem)CbxMainShowCategory.SelectedItem).Content.ToString()));
            }
            else
            {
                MessageBox.Show("Выберите категорию!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
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
            }
           
        }

        private void BtnMainEdit_Click(object sender, RoutedEventArgs e)
        {
            new FormEdit(Id, UserId, Category, Title, Description).ShowDialog();
        }

        private void CbxMainShowCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

                Category = items.Category;
                Title = items.Title;
                Description = items.Description;
                Evaluation = items.Evaluation ?? 0;

                new FormViewItemsFull("Вы", Category, Title, Description, Evaluation.Value).ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
