namespace _08.IncreaseMinionsAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using Connections;

    class Program
    {
        static void Main()
        {
            int[] minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection con = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                con.Open();
                for (int i = 0; i < minionsIds.Length; i++)
                {
                    string increaMinionAgeByOneAndTitleCaseNameQuery = $@"UPDATE Minions
                                                                          SET Name = UPPER(LEFT(Name, 1)) + RIGHT(Name, LEN(Name) -1), Age+=1
                                                                          WHERE MinionID = {minionsIds[i]}";

                    SqlCommand increaseMinionAgeCommand = new SqlCommand(increaMinionAgeByOneAndTitleCaseNameQuery, con);
                    increaseMinionAgeCommand.ExecuteNonQuery();
                }
                string selectNameAndAgeFromMinions =  $@"SELECT m.Name,
	                                                            m.Age
                                                        FROM Minions AS m";
                SqlCommand selectCommand = new SqlCommand(selectNameAndAgeFromMinions, con);
                SqlDataReader reader = selectCommand.ExecuteReader();
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
