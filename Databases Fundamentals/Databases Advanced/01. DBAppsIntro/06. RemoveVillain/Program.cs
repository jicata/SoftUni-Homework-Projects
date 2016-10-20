
namespace _06.RemoveVillain
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Connections;

    class Program
    {
        static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

        
            List<string> messages = new List<string>();

            string deleteVillanMinionsByIdQuery =$@"DELETE FROM VillainsMinions
                                                    WHERE VillainID = {villainId}";

            string getVillainNameById = $@"SELECT v.Name
                                            FROM Villains AS v
                                            WHERE v.VillainID = {villainId}";

            string deleteVillainByIdQuery = $@"DELETE FROM Villains
                                               WHERE VillainID ={villainId}";

            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlTransaction tranToken = connection.BeginTransaction();
                try
                {
                    
                    SqlCommand deleteVillianMinionsCommand = new SqlCommand(deleteVillanMinionsByIdQuery, connection, tranToken);
                    int amountOfMinionsReleased = deleteVillianMinionsCommand.ExecuteNonQuery();

                    SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameById, connection, tranToken);
                    string villainName = getVillainNameCommand.ExecuteScalar().ToString();

                    SqlCommand deleteVillainCommand = new SqlCommand(deleteVillainByIdQuery, connection, tranToken);
                    deleteVillainCommand.ExecuteNonQuery();

                    tranToken.Commit();
                    Console.WriteLine($"{villainName} was deleted");
                    Console.WriteLine($"{amountOfMinionsReleased} minions were released");
                }
                catch (Exception)
                {

                    Console.WriteLine("No such villain was found");
                    tranToken.Rollback();
                }
              
            }
        }
    }
}
