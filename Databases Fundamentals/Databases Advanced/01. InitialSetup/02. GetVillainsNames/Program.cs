namespace _02.GetVillainsNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string connectionString = "Server=6pekIV\\SQLEXPRESS; Database=Minions; Trusted_Connection = true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string groupByVillainName = @"SELECT  v.Name,
		                                              COUNT(*) AS CountOfMinions
                                             FROM VillainsMinions AS vm
	                                             INNER JOIN Villains AS v
		                                             ON vm.VillainID = v.VillainID
                                             GROUP BY v.Name
                                             HAVING COUNT(*) >3
                                             ORDER BY CountOfMinions DESC";
                SqlCommand command = new SqlCommand(groupByVillainName, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{ reader[i]} ");
                    }
                    Console.WriteLine();
                }
                
            }
        }
    }
}
