using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Bll.Concrete;
using BLL.Entities;
using MessageBox = System.Windows.MessageBox;


namespace UserSystem.FormsAddEducations
{
    public partial class FormAdd
    {
        CourseRepository courseRepository = new CourseRepository();

        public string SelectedCategory { get; set; }
        public int UserIdAdd { get; set; }
        public string FilePath { get; set; }
        public string FileNameGuidAdd { get; set; }

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
            TxbxHyperlink.Text = String.Empty;
            TxbxFilePath.Text = String.Empty;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbxTitle.Text != String.Empty && TxbxDescription.Text != String.Empty)
            {
                if (TxbxFilePath.Text != String.Empty)
                {
                    FileNameGuidAdd = String.Format(Guid.NewGuid() + ".zip");
                }
                

                Courses courses = new Courses
                {
                    UserId = UserIdAdd,
                    Category = SelectedCategory,
                    Title = TxbxTitle.Text.Trim(),
                    Description = TxbxDescription.Text.Trim(),
                    Date = String.Format($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"),
                    Hyperlink = TxbxHyperlink.Text.Trim(),
                    FileNameGuid = FileNameGuidAdd
                };
                courseRepository.AddCourse(courses, TxbxTitle, TxbxDescription, TxbxHyperlink, TxbxFilePath);

                if (FileNameGuidAdd != null)
                {
                    Task task = new Task(() => courseRepository.SendFileToDb(UserIdAdd, "172.20.2.221\\", FilePath, FileNameGuidAdd));
                    task.Start();
                }
            }
            else
            {
                MessageBox.Show("Одно или несколько полей не заполнено!", "", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void BtnBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = @"Zip files (*.zip)|*.zip";


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                TxbxFilePath.Text = FilePath;
            }
        }
    }
}
