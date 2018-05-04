using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class QAnswerDAL
    {
        public static List<Model.test> querstion()
        {
            SQLhelper sqlhelper = null;
            sqlhelper = new SQLhelper();
            Model.test testmodel = new Model.test();
            string sql = "select top 1 * FROM test ORDER BY NEWID()";
            DataTable dt = sqlhelper.ExecuteQuery(sql);
            return DatatableToList.ConvertToList<Model.test>(dt);
        }
    }
}
