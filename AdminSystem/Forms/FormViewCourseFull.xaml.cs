using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Bll.Concrete;
using Microsoft.Win32;

namespace AdminSystem.Forms
{

    public partial class FormViewCourseFull
    {
        CourseRepository courseRepository = new CourseRepository();

        public string User { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MyUrlHyperlink { get; set; }
        public string Filepath { get; set; }


        public FormViewCourseFull(int userId, int id, string user, string category, string title, string description, string date, string hyperlink, string myUser, string filePath, int evaluation = 0)
        {
            InitializeComponent();

            User = myUser;
            Id = id;
            UserId = userId;

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            CbxRating.Text = evaluation.ToString();
            TxbxDate.Text = date;
            MyUrlHyperlink = hyperlink;
            Filepath = filePath;

            if (Filepath == null)
            {
                BtnLocalMatherials.IsEnabled = false;
            }
            if (String.IsNullOrEmpty(MyUrlHyperlink))
            {
                Hyperlink.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetRating_Click(object sender, RoutedEventArgs e)
        {
            if (TxBlSetRating.Text == " Назначить баллы")
            {
                CbxRating.IsEnabled = true;
                TxBlSetRating.Text = " Сохранить";
            }
            else if (TxBlSetRating.Text == " Сохранить")
            {
                CbxRating.IsEnabled = false;
                TxBlSetRating.Text = " Назначить баллы";

                courseRepository.SetRatingCourse(UserId, Id, Convert.ToByte(CbxRating.Text.Trim()), User);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (MyUrlHyperlink != String.Empty)
            {
                Process.Start(new ProcessStartInfo(MyUrlHyperlink));
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("Материалы данного курса отсутсвуют!", "", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

        }

        private void BtnLocalMatherials_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
