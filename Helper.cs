using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace ControleTarefas
{
    public static class Helper
    {
        public static string CnnVal()
        {
            return "Server=.\\SQLEXPRESS;Database=ArecoDB1;User Id=sa;Password=@Areco123;";  // ConnectionString - Conexão Banco Database SQL Server
        }
    }
}
