using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface ICoursesRepository
    {
        void AddCourses(Courses courses);

        void DeleteCourses(int id, int userId);

        void EditCourses(Courses courses);

        IEnumerable<Courses> GetAllCourses();

        IEnumerable<Courses> GetCoursesByUserId(int userId);

        IEnumerable<Courses> GetCoursesByUser(Users user);

        IEnumerable<Courses> GetCoursesByPosition(string position);

        IEnumerable<Courses> GetCoursesByFirstname(string firstname);
    }
}
