using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TeacherSystem.Abstract;

namespace TeacherSystem.Concrete
{
    class ContestsRepository : IContestsRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddContests(Contests contests)
        {
            try
            {
                sokoContext.Contests.Add(contests);
                sokoContext.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!", "Добавление записи", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public void DeleteContests(int id, int userId)
        {
            try
            {
                Contests contests = sokoContext.Contests.Where(u => u.UserId == userId).FirstOrDefault(c => c.Id == id);

                if (contests != null)
                {
                    sokoContext.Contests.Remove(contests);
                    sokoContext.SaveChanges();
                    MessageBox.Show("Запись успешно удалена!", "Удаление записи", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void EditContests(Contests contests)
        {
            try
            {
                Contests contestsEdit = sokoContext.Contests.Where(u => u.UserId == contests.UserId).FirstOrDefault(c => c.Id == contests.Id);

                if (contestsEdit != null)
                {
                    contestsEdit.Title = contests.Title;
                    contestsEdit.Description = contests.Description;
                    sokoContext.Contests.AddOrUpdate(contestsEdit);
                    sokoContext.SaveChanges();

                    MessageBox.Show("Запись успешно отредактирована!", "Редактирование записи", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public IEnumerable<Contests> GetAllContests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByUserId(int userId)
        {
            IEnumerable<Contests> contestses = sokoContext.Contests.Where(u => u.UserId == userId).ToList();

            return contestses;
        }

        public IEnumerable<Contests> GetContestsByUser(Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByPosition(string position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByFirstname(string firstname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
