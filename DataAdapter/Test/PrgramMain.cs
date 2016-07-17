using SqlServerDataAdapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class PrgramMain
    {
        static void Main(string[] args)
        {
            string conn = "Data Source=DEC-WINSVR12;Initial Catalog=JCDS;Integrated Security=False;User Id=sa;Password=123";
            SqlServerDataFactory dataFactory = new SqlServerDataFactory(conn);

            DataTable table = new DataTable();
            table.Columns.Add("Name",typeof(string));
            table.Rows.Add("三楼");
            string formulaTable = "formula_FormulaAmmeterDetail";
            int m_InserteRowCount = dataFactory.Insert(formulaTable, table, new string[] { "Name" });

            Console.WriteLine(m_InserteRowCount);
        }
    }
}
