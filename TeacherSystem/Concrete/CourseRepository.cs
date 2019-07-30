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

        public void AddCourse(Courses courses)
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

        public void DeleteCourse(int id, int userId)
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

        public void EditCourse(Courses courses)
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

        public IEnumerable<Courses> GetCoursesByUserId(int userId)
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

        public IEnumerable<Courses> GetCoursesByCategory(int userId, string category)
        {
            IQueryable<Courses> courseses = null;

            try
            {
                courseses = sokoContext.Courses.Where(u => u.UserId == userId).Where(c => c.Category == category);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (courseses != null)
            {
                return courseses.ToList();
            }
            else
            {
                MessageBox.Show("Записи данной категории отсутствуют!", "", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            return null;
        }

        public IEnumerable<Courses> GetCoursesByLastname(string firstname)
        {
            throw new NotImplementedException();
        }


    }
}
