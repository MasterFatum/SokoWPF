using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface ICourseRepository
    {
        void AddCourse(Courses courses);

        void DeleteCourse(int id, int userId);

        void EditCourse(Courses courses);

        IEnumerable<Courses> GetAllCategory();

        IEnumerable<Courses> GetCoursesByUserId(int userId);

        IEnumerable<Courses> GetCoursesByCategory(int userId, string position);

        IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename, string category);


    }
}
