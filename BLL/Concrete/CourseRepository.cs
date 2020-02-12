using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data.Entity.Migrations;
using System.Windows.Controls;
using BLL;
using BLL.Abstract;
using BLL.Entities;

namespace Bll.Concrete
{
    public class CourseRepository : ICourseRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddCourse(Courses courses, TextBox title, TextBox description, TextBox hyperlink, TextBox dataFileName)
        {
            try
            {
                sokoContext.Courses.Add(courses);
                sokoContext.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!", "Добавление записи", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                title.Text = String.Empty;
                description.Text = String.Empty;
                hyperlink.Text = String.Empty;
                dataFileName.Text = String.Empty;
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
                Courses courseEdit = sokoContext.Courses.Where(u => u.UserId == courses.UserId)
                    .FirstOrDefault(c => c.Id == courses.Id);

                if (courseEdit != null)
                {
                    courseEdit.Title = courses.Title;
                    courseEdit.Description = courses.Description;
                    courseEdit.Hyperlink = courses.Hyperlink;
                    courseEdit.FileName = courses.FileName;

                    if (courseEdit.Evaluation != null)
                    {
                        courseEdit.DateEdit =
                            String.Format($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
                    }

                    sokoContext.Courses.AddOrUpdate(courseEdit);
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
                IQueryable<Courses> courseses = new SokoContext().Courses.Where(u => u.UserId == userId);

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

        public IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename, string category)
        {
            Users userId = sokoContext.Users.OrderBy(l => l.Lastname).Where(l => l.Lastname == lastname).Where(f => f.Firstname == firstname)
                .FirstOrDefault(m => m.Middlename == middlename);

            IEnumerable<Courses> courseses = sokoContext.Courses.Where(u => u.UserId == userId.Id)
                .Where(c => c.Category == category);

            return courseses.ToList();
        }

        public IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename)
        {
            Users userId = sokoContext.Users.Where(l => l.Lastname == lastname).Where(f => f.Firstname == firstname)
                .FirstOrDefault(m => m.Middlename == middlename);

            IEnumerable<Courses> courseses = sokoContext.Courses.Where(u => u.UserId == userId.Id);

            return courseses.ToList();
        }

        public void SetRatingCourse(int userId, int id, int rating, string evaluating)
        {
            try
            {
                Courses course = sokoContext.Courses.Where(u => u.UserId == userId).FirstOrDefault(c => c.Id == id);

                if (course != null)
                {
                    course.Evaluation = rating;
                    course.Evaluating = evaluating;

                    sokoContext.Courses.AddOrUpdate(course);
                    sokoContext.SaveChanges();

                    MessageBox.Show("Баллы успешно назначены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SearchInDataGrid(TextBox textBoxSearch, DataGrid dataGrid)
        {
            
        }

        public string AllRating(int userId)
        {
            return sokoContext.Courses.Where(x => x.UserId == userId).Sum(r => r.Evaluation).ToString();
        }


        public IEnumerable<Courses> GetSummaryStatementByFio(string lastname, string firstname, string middlename)
        {
            Users userId = sokoContext.Users.Where(l => l.Lastname == lastname).Where(f => f.Firstname == firstname)
                .FirstOrDefault(m => m.Middlename == middlename);

            var summary = sokoContext.Courses.Where(u => u.UserId == userId.Id).GroupBy(c => c.Category).Select(c => new
            {
                category = c.Key,
                evaluation = c.Sum(e => e.Evaluation)
            }).AsEnumerable().Select(an => new Courses{Category = an.category, Evaluation = an.evaluation});

            return summary.ToList();
              
        }
    }
}
