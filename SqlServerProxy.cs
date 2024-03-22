﻿using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkLoad
{
    internal class SqlServerProxy
    {
        public async Task TestAsync() 
        {
            //Server=tcp:server-testingmsi16764.database.windows.net,1433;Initial Catalog=database-testingmsi16764;Persist Security Info=False;User ID={your_username};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication="Active Directory Integrated";
            //new SqlConnection("Server=tcp:server-testingmsi16764.database.windows.net,1433; Authentication=Active Directory Default; Database=database-testingmsi16764;");
            //"Server=tcp:mi-asc-ecp-dev-mainsqlmidev.public.c105ff79c574.database.windows.net,3342; Authentication=Active Directory Default; Database=dbaeuecpdevtrue;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;";
            //var connectionString = "Server=tcp:mi-asc-ecp-dev-mainsqlmidev.public.c105ff79c574.database.windows.net,3342; Authentication=Active Directory Service Principal; Encrypt=True; Database=dbaeuecpdevtrue; User Id=9a73de36-cbfc-41b4-bf32-47af74dbec03; Password=PP28Q~xwNSzk_ddkkus.I6nLKHv3.1gLDDQ16blS";
            var connectionString = "Server=tcp:mi-asc-ecp-dev-mainsqlmidev.public.c105ff79c574.database.windows.net,3342; Authentication=Active Directory Default; Database=dbaeuecpdevtrue;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;";
            using var connection = new SqlConnection(connectionString);


            await connection.OpenAsync(); 
            Console.WriteLine("Conexión a SqlServer exitosa");  

            var categorias = await connection.QueryAsync<Category>("SELECT TOP 10 CategoryId, Name from [Admin].[Category]");
            var p = categorias.FirstOrDefault();

            Console.WriteLine($"{p.CategoryId}");
        }
    }

    public record Category(int CategoryId, string Name);
}
