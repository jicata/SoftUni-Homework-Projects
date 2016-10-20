namespace _07.PrintAllMinionsNames
{
    using System;
    using System.Data.SqlClient;
    using Connections;

    class Program
    {
        static void Main()
        {
            string getMinionsCountQuery = $@"SELECT COUNT(*)
                                             FROM Minions";
         
            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand getMinionsCountCommand = new SqlCommand(getMinionsCountQuery, connection);
                int totalMinionCount = int.Parse(getMinionsCountCommand.ExecuteScalar().ToString());

                int ascendingRow = 1;
                int descendingRow = totalMinionCount;

                while (ascendingRow <= descendingRow)
                {
                    string getMinionsOverRowsAscendingQuery = $@"SELECT mr.Name
                                                                FROM
                                                                (SELECT m.Name,
		                                                                (ROW_NUMBER() OVER (ORDER BY m.MinionID ) )AS RowNum
                                                                FROM Minions AS m) AS mr
                                                                WHERE mr.RowNum = {ascendingRow} ";

                    string getMinionsOverRowsDescendingQuery = $@"SELECT mr.Name
                                                                FROM
                                                                (SELECT m.Name,
		                                                                (ROW_NUMBER() OVER (ORDER BY m.MinionID ) )AS RowNum
                                                                FROM Minions AS m) AS mr
                                                                WHERE mr.RowNum = {descendingRow} ";

                    SqlCommand getMinionNameAscending = new SqlCommand(getMinionsOverRowsAscendingQuery, connection);
                    SqlCommand getMinionNameDescending = new SqlCommand(getMinionsOverRowsDescendingQuery, connection);

                    string minionName = getMinionNameAscending.ExecuteScalar().ToString();
                    Console.WriteLine(minionName);
                    ascendingRow++;
                    if (ascendingRow >= descendingRow--)
                    {
                        break;
                    }
                    minionName = getMinionNameDescending.ExecuteScalar().ToString();
                    Console.WriteLine(minionName);

                }

            }
        }
    }
}
