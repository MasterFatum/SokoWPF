using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Abstract;

namespace TeacherSystem.Concrete
{
    class OtherRepository : IOtherRepository
    {
        public OtherRepository(int id, string category)
        {

        }

        public void GetCategoryByName(int userId, string category)
        {
            throw new NotImplementedException();
        }
    }
}
