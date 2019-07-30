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
    public partial class FormEdit : Window
    {
        CourseRepository courseRepository = new CourseRepository();

        public int Id { get; set; }
        public int UserIdEdit { get; set; }
        public string CategoryEdit { get; set; }
        public string TitleEdit { get; set; }
        public string DescriptionEdit { get; set; }


        public FormEdit(int id, int userIdEdit, string categoryEdit, string title, string description)
        {
            InitializeComponent();

            Id = id;
            UserIdEdit = userIdEdit;
            TxbxEditCategory.Text = categoryEdit;
            TxbxEditTitle.Text = title;
            TxbxEditDescription.Text = description;
        }

        private void BtnEditExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEditSave_Click(object sender, RoutedEventArgs e)
        {
            Courses courses = new Courses
            {
                Id = Id,
                UserId = UserIdEdit,
                Category = CategoryEdit,
                Title = TxbxEditTitle.Text.Trim(),
                Description = TxbxEditDescription.Text.Trim()
            };

            courseRepository.EditCourse(courses);
            this.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxEditTitle.Text = String.Empty;
            TxbxEditDescription.Text = String.Empty;
        }
    }
}
