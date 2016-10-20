namespace _04.AddMinion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Connections;

    class Program
    {
        static void Main()
        {
            bool townExists = false;
            bool villainExists = false;

            List<string> successMessages = new List<string>();
            Console.Write("Minion: ");
            string[] minionDetails = Console.ReadLine().Split();
            Console.Write("Villain: ");
            string villainName = Console.ReadLine();

            string townQuery = $@"SELECT  t.Name
                                FROM Towns AS t
                                WHERE t.Name ='{minionDetails[2]}'";

            string villainQuery = $@"SELECT  v.Name
                                    FROM Villains AS v
                                    WHERE v.Name = '{villainName}'";

            //to be used only if upper query returns nothing
            string insertTownQuery = $@"INSERT INTO Towns(Name) VALUES
                                      ('{minionDetails[2]}')";

            string getTownIdQuery = $@"SELECT  t.TownID
                                    FROM Towns AS t
                                    WHERE t.Name ='{minionDetails[2]}'";

            //to be used only if upper query returns nothing
            string insertVillainQuery = $@"INSERT INTO Villains(Name, EvilnessFactor) VALUES
                                           ('{villainName}','Evil')";

            string getVillainIdQuery = $@"SELECT  v.VillainID
                                        FROM Villains AS v
                                        WHERE v.Name = '{villainName}'";

            string getMinionIdQuery = $@"SELECT m.MinionID
                                    FROM Minions AS m
                                    WHERE m.Name = '{minionDetails[0]}'";
        
            using (SqlConnection connection = new SqlConnection(DefaultDatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlTransaction objTrans = connection.BeginTransaction();
                try
                {
                    //check whether villain/town exists
                SqlCommand townCommand = new SqlCommand(townQuery,connection, objTrans);
                SqlCommand villainCommand = new SqlCommand(villainQuery, objTrans.Connection, objTrans);


                townExists = townCommand.ExecuteScalar() != null;
                villainExists = villainCommand.ExecuteScalar() != null;
                
                    //insert town if doesn't exist
                    if (!townExists)
                    {
                        SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, connection, objTrans);
                        insertTownCommand.ExecuteNonQuery();
                        string townSuccess = $"Town {minionDetails[2]} was added to the database";
                        successMessages.Add(townSuccess);
                    }
                    //insert villain if doesn't exist
                    if (!villainExists)
                    {
                        SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuery, connection, objTrans);
                        insertVillainCommand.ExecuteNonQuery();
                        string villainSuccess = $"Villain {villainName} was added to the database";
                        successMessages.Add(villainSuccess);
                    }

                    //get townId
                    SqlCommand getTownIdCommand = new SqlCommand(getTownIdQuery, connection, objTrans);
                    int townId = (int) getTownIdCommand.ExecuteScalar();

                    //insert minion and get its ID
                    string insertMinionQuery =
                        $@"INSERT INTO Minions(Name, Age, TownID) VALUES
                                          ('{minionDetails[0]}', {minionDetails[1]}, {townId})";
                    SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuery, connection, objTrans);
                    insertMinionCommand.ExecuteNonQuery();

                    SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQuery, connection, objTrans);
                    int minionId = (int) getMinionIdCommand.ExecuteScalar();

                    //get villainId
                    SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuery, connection, objTrans);
                    int villainId = (int) getVillainIdCommand.ExecuteScalar();

                    //insert Minion ID and Villain ID into VillainsMinions many-to-any table
                    string insertVillainMinionQuery =
                        $@"INSERT INTO VillainsMinions(VillainID, MinionID) VALUES
                                                 ({villainId},{minionId})";
                    string minionSuccess = $"Successfully added {minionDetails[0]} to be minion of {villainName}";
                    successMessages.Add(minionSuccess);
                    SqlCommand insertVillansMinionsManyToMany = new SqlCommand(insertVillainMinionQuery, connection, objTrans);
                    insertVillansMinionsManyToMany.ExecuteNonQuery();

                    objTrans.Commit();
                    foreach (var successMessage in successMessages)
                    {
                        Console.WriteLine(successMessage);
                    }
                }
                catch (Exception e)
                {

                    objTrans.Rollback();
                    Console.WriteLine("Error during transaction");
                    Console.WriteLine(e.InnerException);
                    Console.WriteLine("Rollback");
                }

            }
           
        }
    }
}
