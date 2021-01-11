using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace P08._Increase_Minion_Age
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string connectionString = "Server=.; Database=MinionsDB; Integrated Security=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            foreach (var minionId in input)
            {
                string changeAgeCmdString = "UPDATE Minions " +
                                             "SET Age += 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) " +
                                             "WHERE Id = @minionId ";
                using SqlCommand changeAgeCmd = new SqlCommand(changeAgeCmdString, sqlConnection);
                changeAgeCmd.Parameters.AddWithValue("@minionId", minionId);
                changeAgeCmd.ExecuteNonQuery();
            }

            string printMinionsCmdString = "SELECT Name, Age FROM Minions";
            using SqlCommand printMinionsCmd = new SqlCommand(printMinionsCmdString, sqlConnection);

            using SqlDataReader reader = printMinionsCmd.ExecuteReader();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];
                Console.WriteLine(minionName + " " + minionAge);
            }
        }
    }
}
