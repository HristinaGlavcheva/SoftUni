using System;
using System.Data.SqlClient;

namespace P02._Villain_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string sqlConnectionString = "Server = .; Database = MinionsDB; Integrated Security = true;";
            using SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            
            sqlConnection.Open();

            string queryString = "SELECT v.Name, COUNT(MinionID) AS [Count] " +
                                  "FROM Villains v " +
                                  "JOIN MinionsVillains mv ON mv.VillainId = v.Id " +
                                  "GROUP BY VillainId, v.Name " +
                                  "HAVING COUNT(MinionID) > 3" +
                                  "ORDER BY [Count] DESC";

            using SqlCommand command = new SqlCommand(queryString, sqlConnection);

            using SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string villainsName = (string)reader["Name"];
                int minionsCount = (int)reader["Count"];

                Console.WriteLine($"{villainsName} - {minionsCount}");
            }
        }
    }
}
