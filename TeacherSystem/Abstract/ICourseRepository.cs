using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface ICourseRepository
    {
        void AddCategory(Courses contests);

        void DeleteCategory(int id, int userId);

        void EditCategory(Courses contests);

        IEnumerable<Courses> GetAllCategory();

        IEnumerable<Courses> GetCategoryByUserId(int userId);

        IEnumerable<Courses> GetCategoryByPosition(int userId, string position);

        IEnumerable<Courses> GetCategoryByLastname(string firstname);


    }
}
