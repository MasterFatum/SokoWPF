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


        public MainWindow(Users user)
        {
            InitializeComponent();

            TxbxUserId.Text = user.Id.ToString();
            TxbxUserLastname.Text = user.Lastname;
            TxbxUserFirstname.Text= user.Firstname;
            TxbxUserMiddlename.Text = user.Middlename;
            TxbxUserPosition.Text = user.Position;

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

        private void BtnMainCategoryShow_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            new FormChooseEducation(Convert.ToInt32(TxbxUserId.Text)).ShowDialog();
        }

        private void BtnMainUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataGridMain.ItemsSource = contestsRepository.GetContestsByUserId(Convert.ToInt32(TxbxUserId.Text));
        }
    }
}
