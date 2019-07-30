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
    class CourseRepository : ICourseRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddCategory(Courses courses)
        {
            try
            {
                sokoContext.Courses.Add(courses);
                sokoContext.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!", "Добавление записи", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public void DeleteCategory(int id, int userId)
        {
            try
            {
                Courses courses = sokoContext.Courses.Where(u => u.UserId == userId).FirstOrDefault(c => c.Id == id);

                if (courses != null)
                {
                    sokoContext.Courses.Remove(courses);
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

        public void EditCategory(Courses courses)
        {
            try
            {
                Courses contestsEdit = sokoContext.Courses.Where(u => u.UserId == courses.UserId).FirstOrDefault(c => c.Id == courses.Id);

                if (contestsEdit != null)
                {
                    contestsEdit.Title = courses.Title;
                    contestsEdit.Description = courses.Description;
                    sokoContext.Courses.AddOrUpdate(contestsEdit);
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

        public IEnumerable<Courses> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCategoryByUserId(int userId)
        {
            try
            {
                IQueryable<Courses> courseses = sokoContext.Courses.Where(u => u.UserId == userId);

                return courseses.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public IEnumerable<Courses> GetCategoryByPosition(int userId, string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCategoryByLastname(string firstname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetContestsByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
