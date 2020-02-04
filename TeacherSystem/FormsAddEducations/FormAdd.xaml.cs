using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Bll.Concrete;
using BLL.Concrete;
using BLL.Entities;
using MessageBox = System.Windows.MessageBox;


namespace UserSystem.FormsAddEducations
{
    public partial class FormAdd
    {
        CourseRepository courseRepository = new CourseRepository();
        FtpRepository ftpRepository = new FtpRepository();

        public string SelectedCategory { get; set; }
        public int UserIdAdd { get; set; }
        public string FilePath { get; set; }
        public string FileNameGuid { get; set; }

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
                FileNameGuid = Guid.NewGuid().ToString();

                Courses courses = new Courses
                {
                    UserId = UserIdAdd,
                    Category = SelectedCategory,
                    FileName = FileNameGuid,
                    Title = TxbxTitle.Text.Trim(),
                    Description = TxbxDescription.Text.Trim(),
                    Date = String.Format($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"),
                    Hyperlink = TxbxHyperlink.Text.Trim()
                };
                

                if (TxbxFilePath.Text != String.Empty)
                {
                    ftpRepository.UseSsl = false;
                    ftpRepository.Host = "172.20.2.221";
                    ftpRepository.Username = "anonymous";
                    ftpRepository.Password = "sko@fckrasnodar.ru";
                    Task task = new Task(() => ftpRepository.UploadFile("/" + UserIdAdd + "/", FilePath, FileNameGuid));
                    task.Start();
                }
                courseRepository.AddCourse(courses, TxbxTitle, TxbxDescription, TxbxHyperlink, TxbxFilePath);
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

            openFileDialog.Filter = @"(*.zip)|*.zip";

            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                long fileLength = new FileInfo(openFileDialog.FileName).Length;

                if (fileLength > 52428800)
                {
                    MessageBox.Show("Размер файла превышает допустимый! Размер файла не должен превышать 50 MB.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    FilePath = openFileDialog.FileName;
                    TxbxFilePath.Text = FilePath;
                }
            }
        }
    }
}
