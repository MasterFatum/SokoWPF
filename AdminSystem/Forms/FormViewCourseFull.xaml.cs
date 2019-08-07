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
using Bll.Concrete;

namespace AdminSystem.Forms
{
    /// <summary>
    /// Логика взаимодействия для FormViewCourseFull.xaml
    /// </summary>
    public partial class FormViewCourseFull : Window
    {
        CourseRepository courseRepository = new CourseRepository();

        public int Id { get; set; }
        public int UserId { get; set; }


        public FormViewCourseFull(int userId, int id, string user, string category, string title, string description, int evaluation = 0)
        {
            InitializeComponent();

            Id = id;
            UserId = userId;

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            TxbxEvaluation.Text = evaluation.ToString();
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
