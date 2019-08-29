using System.Collections.Generic;
using System.Windows.Controls;
using BLL.Entities;

namespace BLL.Abstract
{
    interface ICourseRepository
    {
        void AddCourse(Courses courses, TextBox title, TextBox description, TextBox hyperlink);

        void DeleteCourse(int id, int userId);

        void EditCourse(Courses courses);

        IEnumerable<Courses> GetAllCategory();

        IEnumerable<Courses> GetCoursesByUserId(int userId);

        IEnumerable<Courses> GetCoursesByCategory(int userId, string position);

        IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename);

        IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename, string category);

        void SetRatingCourse(int userId, int id, int rating);

        string AllRating(int userId);
    }
}
