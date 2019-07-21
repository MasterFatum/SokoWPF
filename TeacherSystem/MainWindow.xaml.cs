using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeacherSystem.Concrete;
using TeacherSystem.FormAddEducations;

namespace TeacherSystem
{
    public partial class MainWindow : Window
    {

        ContestsRepository contestsRepository = new ContestsRepository();

        SokoContext sokoContext = new SokoContext();

        public MainWindow(Users user)
        {
            InitializeComponent();

            LblUserId.Content = user.Id;
            LblLastname.Content = user.Lastname;
            LblLFirstname.Content = user.Firstname;
            LblMeddlename.Content = user.Middlename;
            LblPosition.Content = user.Position;

            IEnumerable<Contests> contestses = contestsRepository.GetContestsByUserId(user.Id);

            DataGridMain.ItemsSource = contestses.ToList();
        }

        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        private void BtnMainExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            new FormChooseEducation().ShowDialog();
        }

        private void BtnMainAdd_Click_1(object sender, RoutedEventArgs e)
        {
            new FormChooseEducation().ShowDialog();
        }
    }
}
