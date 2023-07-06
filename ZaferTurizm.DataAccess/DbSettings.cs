using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DataAccess
{
    internal class DbSettings
    {
        
        
            public const string ConnectionLaptopStringSettings = @"Server=DESKTOP-S7P89NR\MSSQLSERVER01;Database= ZaferTurizm01;
            Integrated Security=true; TrustServerCertificate=True";
            public const string DbConnectionString = "Server=DESKTOP-VO8N54A\\SQLEXPRESS; Database=zaferDBsET; Integrated Security=true;";
            public const string ConnectionPcStringSettings = @"Server=DESKTOP-SH3EO74;Database= ZaferTurizm01; 
            Integrated Security=true; TrustServerCertificate=True";
            public const string ProductionStringSettings = "";
             public const string DbMertSettings = "Server=.; Database=ZaferTurizmDb1; Integrated Security=true;";


        // const olduğu için instance almadan erişebiliyoruz
    }
}
