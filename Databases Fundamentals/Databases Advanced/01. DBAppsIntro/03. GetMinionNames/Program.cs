namespace _03.GetMinionNames
{
    using System;
    using System.Data.SqlClient;
    using Connections;

    class Program
    {
        static void Main()
        {

            int villainId = int.Parse(Console.ReadLine());
            string villainName = string.Empty;
            string getVillainNameByIdQuery = @"SELECT  v.Name
                                            FROM Villains AS v
                                            WHERE v.VillainID = " + villainId;

            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(getVillainNameByIdQuery, connection);
                try
                {
                    villainName = command.ExecuteScalar().ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine("No villain with ID 10 exists in the database.");
                    return;
                }

            }

            string minionsForVillain = @"SELECT  m.Name,
		                                         m.Age
                                         FROM VillainsMinions AS vm
	                                         INNER JOIN Minions AS m
		                                         ON vm.MinionID = m.MinionID
		                                         AND vm.VillainID = " + villainId;

            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(minionsForVillain, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int counter = 1;
                    Console.WriteLine($"Villain: {villainName}");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Console.Write($"{counter}. {reader[0]} {reader[1]}");
                            counter++;
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("<no minions>");
                    }
                }
            }



        }
    }
}
