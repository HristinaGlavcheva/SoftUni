﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace P01._Initial_Setup
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionStringCreateDb = "Server=.; Database=master; Integrated Security = true";
            using SqlConnection sqlConnectionCreateDb = new SqlConnection(connectionStringCreateDb);
            
            sqlConnectionCreateDb.Open();
            using SqlCommand createDbCommand = new SqlCommand("CREATE DATABASE MinionsDB", sqlConnectionCreateDb);
            createDbCommand.ExecuteNonQuery();

            string connectionStringCreateAndPopulateTables = "Server=.; Database=MinionsDB; Integrated Security = true";
            using SqlConnection sqlConnectionCreateAndPopulateTables = new SqlConnection(connectionStringCreateAndPopulateTables);
            
           sqlConnectionCreateAndPopulateTables.Open();

           List<String> createTablesQueries = new List<string>();

           string createTableCountriesQuery = "CREATE TABLE Countries" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50))";
                
           string createTableTownsQuery = "CREATE TABLE Towns" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50)," +
                                                        "CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
               
           string createTableMinionsQuery = "CREATE TABLE Minions" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(30)," +
                                                        "Age INT," +
                                                        "TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                
           string createTableEvilnessFactorsQuery = "CREATE TABLE EvilnessFactors" +
                                                                "(Id INT PRIMARY KEY IDENTITY," +
                                                                "Name VARCHAR(50))";
               
           string createTableVillainsQuery = "CREATE TABLE Villains" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50)," +
                                                        "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                
           string createTableMinionsVillainsQuery = "CREATE TABLE MinionsVillains" +
                                                                "(MinionId INT FOREIGN KEY REFERENCES Minions(Id)," +
                                                                "VillainId INT FOREIGN KEY REFERENCES Villains(Id)," +
                                                                "CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

           createTablesQueries.Add(createTableCountriesQuery);
           createTablesQueries.Add(createTableTownsQuery);
           createTablesQueries.Add(createTableMinionsQuery);
           createTablesQueries.Add(createTableEvilnessFactorsQuery);
           createTablesQueries.Add(createTableVillainsQuery);
           createTablesQueries.Add(createTableMinionsVillainsQuery);

           foreach (var query in createTablesQueries)
           {
               createAndPopulateTable(query, sqlConnectionCreateAndPopulateTables);
           }
           
           List<String> populateTablesQueries = new List<string>();
           
           string insertIntoTableCountriesQuery = "INSERT INTO Countries ([Name]) " +
                                                   "VALUES " +
                                                   "('Bulgaria')," +
                                                   "('England')," +
                                                   "('Cyprus')," +
                                                   "('Germany')," +
                                                   "('Norway')";
           
           string insertIntoTableTownsQuery = "INSERT INTO Towns ([Name], CountryCode) " +
                                                   "VALUES " +
                                                   "('Plovdiv', 1)," +
                                                   "('Varna', 1)," +
                                                   "('Burgas', 1)," +
                                                   "('Sofia', 1)," +
                                                   "('London', 2)," +
                                                   "('Southampton', 2)," +
                                                   "('Bath', 2)," +
                                                   "('Liverpool', 2)," +
                                                   "('Berlin', 3)," +
                                                   "('Frankfurt', 3)," +
                                                   "('Oslo', 4)";

           string insertIntoTableMinionsQuery = "INSERT INTO Minions (Name,Age, TownId) " +
                                                   "VALUES" +
                                                   "('Bob', 42, 3)," +
                                                   "('Kevin', 1, 1)," +
                                                   "('Bob ', 32, 6)," +
                                                   "('Simon', 45, 3)," +
                                                   "('Cathleen', 11, 2)," +
                                                   "('Carry ', 50, 10)," +
                                                   "('Becky', 125, 5)," +
                                                   "('Mars', 21, 1)," +
                                                   "('Misho', 5, 10)," +
                                                   "('Zoe', 125, 5)," +
                                                   "('Json', 21, 1)";

           string insertIntoTableEvilnessFactorsQuery = "INSERT INTO EvilnessFactors (Name) " +
                                                           "VALUES" +
                                                           "('Super good')," +
                                                           "('Good')," +
                                                           "('Bad')," +
                                                           "('Evil')," +
                                                           "('Super evil')";

           string insertIntoTableVillainsQuery = "INSERT INTO Villains (Name, EvilnessFactorId) " +
                                                       "VALUES " +
                                                       "('Gru',2)," +
                                                       "('Victor',1)," +
                                                       "('Jilly',3)," +
                                                       "('Miro',4)," +
                                                       "('Rosen',5)," +
                                                       "('Dimityr',1)," +
                                                       "('Dobromir',2)";

           string insertIntoTableMinionsVillainsQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) " +
                                                           "VALUES" +
                                                           "(4,2)," +
                                                           "(1,1)," +
                                                           "(5,7)," +
                                                           "(3,5)," +
                                                           "(2,6)," +
                                                           "(11,5)," +
                                                           "(8,4)," +
                                                           "(9,7)," +
                                                           "(7,1)," +
                                                           "(1,3)," +
                                                           "(7,3)," +
                                                           "(5,3)," +
                                                           "(4,3)," +
                                                           "(1,2)," +
                                                           "(2,1)," +
                                                           "(2,7)";

           populateTablesQueries.Add(insertIntoTableCountriesQuery);
           populateTablesQueries.Add(insertIntoTableTownsQuery);
           populateTablesQueries.Add(insertIntoTableMinionsQuery);
           populateTablesQueries.Add(insertIntoTableEvilnessFactorsQuery);
           populateTablesQueries.Add(insertIntoTableVillainsQuery);
           populateTablesQueries.Add(insertIntoTableMinionsVillainsQuery);

           foreach (var query in populateTablesQueries)
           {
               createAndPopulateTable(query, sqlConnectionCreateAndPopulateTables);
           }
        }

        private static void createAndPopulateTable(string createAndPopulateTableQuery, SqlConnection sqlConnectionCreateAndPopulateTables)
        {
            using SqlCommand createAndPopulateTableCommand = new SqlCommand(createAndPopulateTableQuery, sqlConnectionCreateAndPopulateTables);
            createAndPopulateTableCommand.ExecuteNonQuery();
        }
    }
}
