namespace _05.ChangeTownNameCasing
{
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using Connections;

    class Program
    {
        static void Main()
        {
            string countryName = Console.ReadLine();
            string upperTowns =$@"UPDATE Towns
                                  SET Name = UPPER(Name)
                                  WHERE Country = '{countryName}'
                                  AND Name != UPPER(Name)";
            // query works only if collation of the table/column 
            // is set to SQL_Latin1_General_CP1_CS_AS otherwise string matching is case-insenstive

            string townsAfterUpper =$@"SELECT t.Name
                                       FROM Towns AS t
                                       WHERE t.Country = '{countryName}'";

            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand upperTownsCommand = new SqlCommand(upperTowns, connection);
                int rowsAffected = upperTownsCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"{rowsAffected} town names were affected.");
                    SqlCommand getUpdatedNamesCommand = new SqlCommand(townsAfterUpper, connection);
                    SqlDataReader reader = getUpdatedNamesCommand.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    using (reader)
                    {
                        sb.Append("[");
                        while (reader.Read())
                        {
                            sb.Append($"{reader[0]}, ");
                        }
                        sb.Remove(sb.Length - 2, 2);
                        sb.Append("]");
                    }
                    Console.WriteLine(sb);
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
                
            }
        }
    }
}
