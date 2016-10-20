namespace _01.InitialSetup
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main()
        {
            string connectionString = "Server=6pekIV\\SQLEXPRESS; Trusted_Connection = true";
            string dbCreationQuery = "CREATE DATABASE Minions;";

           // SqlConnection connection = new SqlConnection(connectionString);
          

            // Creating the DB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand createDbCommand = new SqlCommand(dbCreationQuery, connection);
                createDbCommand.ExecuteNonQuery();
            }


            // DDL
            connectionString = "Server=6pekIV\\SQLEXPRESS; Database=Minions; Trusted_Connection = true";
            

            string townsTableCreation = "CREATE TABLE Towns " +
                                       "(" +
                                       "TownID INT IDENTITY(1,1) PRIMARY KEY, " +
                                       "Name VARCHAR(50), " + 
                                       "Country VARCHAR(50) " +
                                       ")";

            string minionsTableCreation = "CREATE TABLE Minions " +
                                         "(" +
                                         "MinionID INT IDENTITY(1,1) PRIMARY KEY, " +
                                         "Name VARCHAR(50), " +
                                         "Age INT, " +
                                         "TownID INT CONSTRAINT FK_Minions_Towns FOREIGN KEY REFERENCES Towns(TownID)" +
                                         ")";

            string villainsTableCreation = "CREATE TABLE Villains " +
                                          "(" +
                                          "VillainID INT IDENTITY(1,1) PRIMARY KEY, " +
                                          "Name VARCHAR(50), " +
                                          "EvilnessFactor VARCHAR(10) NOT NULL CHECK (EvilnessFactor IN ('Good', 'Bad', 'Evil', 'Super Evil'))" +
                                          ")";

            string villainsMinionManyToManyTableCreation = "CREATE TABLE VillainsMinions " +
                                                           "(" +
                                                           "VillainID INT NOT NULL, " +
                                                           "MinionID INT NOT NULL, " +
                                                           "CONSTRAINT PK_Villains_Minions PRIMARY KEY(VillainID, MinionID), " +
                                                           "CONSTRAINT FK_VillainsMinions_Villains FOREIGN KEY(VillainID) REFERENCES Villains(VillainID), " +
                                                           "CONSTRAINT FK_VilliansMinions_Minions FOREIGN KEY(MinionID) REFERENCES Minions(MinionID)" +
                                                           ")";

            string[] creationCommands = new[]
            {townsTableCreation, minionsTableCreation, villainsTableCreation, villainsMinionManyToManyTableCreation};

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var creationCommand in creationCommands)
                {
                    
                    SqlCommand command = new SqlCommand(creationCommand, connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }


            // DML

            string townsData = "INSERT INTO Towns(Name, Country) VALUES " +
                                  "('Sofia', 'Bulgaria'), " +
                                  "('London', 'UK'), " +
                                  "('Beograd', 'Serbia'), " +
                                  "('Aarhus', 'Denmark'), " +
                                  "('Plovdiv', 'Bulgaria')";
            string minionsData = "INSERT INTO Minions(Name, Age, TownID) VALUES " +
                                 "('Pesho', 15, 1), " +
                                 "('Kris', 16, 5), " +
                                 "('HengryG', 28, 2), " +
                                 "('Sanja', 27, 3), " +
                                 "('Line', 45, 4)";
            string villainsData = "INSERT INTO Villains(Name, EvilnessFactor) VALUES " +
                                  "('Scrooge', 'Good'), " +
                                  "('Mellisandre', 'Bad'), " +
                                  "('NightKing', 'Super Evil'), " +
                                  "('Morgoth', 'Super Evil'), " +
                                  "('TheJoker', 'Evil')";
            string villainsMinionsData = "INSERT INTO VillainsMinions(VillainID, MinionID) VALUES " +
                                         "(1,1), " +
                                         "(2,4), " +
                                         "(2,2), " +
                                         "(4,5), " +
                                         "(5,4)";
            string[] DMLCommands = new[] {townsData, minionsData, villainsData, villainsMinionsData};

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var dmlCommand in DMLCommands)
                {
                    SqlCommand command = new SqlCommand(dmlCommand, connection);
                    Console.WriteLine(command.ExecuteNonQuery());
                    
                }
            }
        }
    }
}
