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

namespace TeacherSystem.FormAddEducations
{
    public partial class FormAdd : Window
    {
        ContestsRepository contestsRepository = new ContestsRepository();
        CoursesRepository coursesRepository = new CoursesRepository();

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

            switch (SelectedCategory)
            {
                case "Конкурсы":
                    Contests contests = new Contests
                    {
                        UserId = UserIdAdd,
                        Category = TxbxSelectedCategory.Text.Trim(),
                        Title = TxbxTitle.Text.Trim(),
                        Description = TxbxDescription.Text.Trim()

                    };

                    contestsRepository.AddContests(contests);

                    TxbxTitle.Text = String.Empty;
                    TxbxDescription.Text = String.Empty;
                    break;
                case "Курсы":
                    Courses courses = new Courses
                    {
                        UserId = UserIdAdd,
                        Category = TxbxSelectedCategory.Text.Trim(),
                        Title = TxbxTitle.Text.Trim(),
                        Description = TxbxDescription.Text.Trim()

                    };

                    coursesRepository.AddCourses(courses);

                    TxbxTitle.Text = String.Empty;
                    TxbxDescription.Text = String.Empty;
                    break;
            }
            
        }
    }
}
