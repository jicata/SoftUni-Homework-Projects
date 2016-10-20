namespace _09.IncreaseAgeStoredProc
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Connections;

    class Program
    {
        static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());
            using (SqlConnection con = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                con.Open();
                SqlCommand procCommand = new SqlCommand("usp_GetOlder", con);
                procCommand.CommandType = CommandType.StoredProcedure;
                procCommand.Parameters.Add(new SqlParameter("@MinionID", minionId));
                procCommand.ExecuteNonQuery();


                string selectMinionWithId = $@"SELECT m.Name,
	                                                  m.Age
                                            FROM Minions AS m
                                            WHERE m.MinionID = {minionId}";

                SqlCommand selectMinion = new SqlCommand(selectMinionWithId, con);
                SqlDataReader reader = selectMinion.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }

        }
    }
}
