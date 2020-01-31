using System;
using System.Windows;
using Bll.Concrete;
using BLL.Entities;

namespace UserSystem.FormsAddEducations
{
    public partial class FormEdit
    {
        CourseRepository courseRepository = new CourseRepository();

        public int Id { get; set; }
        public int UserIdEdit { get; set; }
        public string CategoryEdit { get; set; }
        public string TitleEdit { get; set; }
        public string DescriptionEdit { get; set; }
        public string HyperlinkEdit { get; set; }
        public string FilePath { get; set; }
        public string DateEdit { get; set; }


        public FormEdit(int id, int userIdEdit, string categoryEdit, string title, string description, string hyperlink, string filePath)
        {
            InitializeComponent();

            Id = id;
            UserIdEdit = userIdEdit;
            TxbxEditCategory.Text = categoryEdit;
            TxbxEditTitle.Text = title;
            TxbxEditDescription.Text = description;
            TxbxHyperlink.Text = hyperlink;
            TxbxFilePath.Text = filePath;
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
                Description = TxbxEditDescription.Text.Trim(),
                Hyperlink = TxbxHyperlink.Text.Trim(),
                
            };

            courseRepository.EditCourse(courses);
            Close();
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxEditTitle.Text = String.Empty;
            TxbxEditDescription.Text = String.Empty;
            TxbxHyperlink.Text = String.Empty;
        }
    }
}
