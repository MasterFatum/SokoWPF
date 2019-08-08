using System;
using System.Windows;
using Bll.Concrete;

namespace AdminSystem.Forms
{

    public partial class FormViewCourseFull : Window
    {
        CourseRepository courseRepository = new CourseRepository();

        public int Id { get; set; }
        public int UserId { get; set; }


        public FormViewCourseFull(int userId, int id, string user, string category, string title, string description, string date, int evaluation = 0)
        {
            InitializeComponent();

            Id = id;
            UserId = userId;

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            TxbxEvaluation.Text = evaluation.ToString();
            TxbxDate.Text = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetRating_Click(object sender, RoutedEventArgs e)
        {
            if (TxBlSetRating.Text == " Назначить баллы")
            {
                TxbxEvaluation.IsReadOnly = false;
                TxbxEvaluation.IsEnabled = true;
                TxBlSetRating.Text = " Сохранить";
            }
            else if (TxBlSetRating.Text == " Сохранить")
            {
                TxbxEvaluation.IsReadOnly = true;
                TxbxEvaluation.IsEnabled = false;
                TxBlSetRating.Text = " Назначить баллы";

                courseRepository.SetRatingCourse(UserId, Id, Convert.ToByte(TxbxEvaluation.Text.Trim()));
            }
        }
    }
}
