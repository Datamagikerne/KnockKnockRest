﻿namespace KnockKnockRest
{
    public class Secrets
    {

        //public static readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KnockKnockLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // localdb
        //public static readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReceiptShareDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public static readonly string ConnectionString = "Data Source=knockknockserver2.database.windows.net;Initial Catalog=KnockKnockDB;User ID=knockknockadmin;Password=pepsimax123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
