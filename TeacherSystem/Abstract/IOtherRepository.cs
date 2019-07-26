using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface IOtherRepository
    {
        void GetCategoryByName(int userId, string category);
    }
}
