using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkLoad
{
    internal class SqlServerProxy
    {
        public async Task TestAsync() 
        {
            var connectionString = "Server=tcp:mi-asc-ecp-dev-mainsqlmidev.public.c105ff79c574.database.windows.net,3342; Authentication=Active Directory Default; Database=dbaeuecpdevtrue;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;";
            using var connection = new SqlConnection(connectionString);

            await connection.OpenAsync(); 
            Console.WriteLine("Conexión a SqlServer exitosa");  

            var categorias = await connection.QueryAsync<Category>("SELECT TOP 10 CategoryId, Name from [Admin].[Category]");
            var p = categorias.FirstOrDefault();

            Console.WriteLine($"{p.CategoryId}");
        }
    }
}
