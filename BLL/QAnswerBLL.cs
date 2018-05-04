using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QAnswerBLL
    {
        public static List<Model.test> querstionBll()
        {
            return DLL.QAnswerDAL.querstion();
        }
    }
}
