using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeacherSystem.Abstract;

namespace TeacherSystem.Concrete
{
    class CoursesRepository : ICoursesRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddCourses(Courses courses)
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

        public void DeleteCourses(int id, int userId)
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

        public void EditCourses(Courses courses)
        {
            try
            {
                Courses coursesEdit = sokoContext.Courses.Where(u => u.UserId == courses.UserId).FirstOrDefault(c => c.Id == courses.Id);

                if (coursesEdit != null)
                {
                    coursesEdit.Title = courses.Title;
                    coursesEdit.Description = courses.Description;
                    sokoContext.Courses.AddOrUpdate(coursesEdit);
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

        public IEnumerable<Courses> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCoursesByUserId(int userId)
        {
            try
            {
                IEnumerable<Courses> courseses = sokoContext.Courses.Where(u => u.UserId == userId).ToList();

                return courseses;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public IEnumerable<Courses> GetCoursesByUser(Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCoursesByPosition(string position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCoursesByFirstname(string firstname)
        {
            throw new NotImplementedException();
        }
    }
}
