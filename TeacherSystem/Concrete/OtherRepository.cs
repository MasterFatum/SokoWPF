using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Abstract;

namespace TeacherSystem.Concrete
{
    class OtherRepository : IOtherRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void GetCategoryByName(int userId, string category)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetAllCategoryByUserId(int userId)
        {
            ArrayList items = new ArrayList();

            items.AddRange(sokoContext.Contests.Where(u => u.UserId == userId).ToArray());
            items.AddRange(sokoContext.Courses.Where(u => u.UserId == userId).ToArray());

            return items;
        }
    }
}
