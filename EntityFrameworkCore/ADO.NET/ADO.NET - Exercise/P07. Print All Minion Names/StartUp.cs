using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace P07._Print_All_Minion_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Integrated Security=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            List<string> minions = new List<string>();

            string addMinionsCmdText = "SELECT Name FROM Minions";
            using SqlCommand addMinionsCmd = new SqlCommand(addMinionsCmdText, sqlConnection);

            using SqlDataReader reader = addMinionsCmd.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                minions.Add(name);
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - i - 1]);
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }
    }
}
