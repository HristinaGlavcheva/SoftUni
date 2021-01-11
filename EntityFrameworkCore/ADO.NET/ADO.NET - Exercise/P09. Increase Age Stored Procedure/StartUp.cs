using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace P09._Increase_Age_Stored_Procedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Integrated Security=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            using SqlCommand getOlderCmd = new SqlCommand("usp_GetOlder", sqlConnection);
            getOlderCmd.CommandType = CommandType.StoredProcedure;
            getOlderCmd.Parameters.AddWithValue("@Id", minionId);

            getOlderCmd.ExecuteNonQuery();

            string getMinionInfoCmdText = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            using SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoCmdText, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@Id", minionId);

            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();

            reader.Read();

            string minionName = (string)reader["Name"];
            int? minionAge = (int?)reader["Age"];

            Console.WriteLine($"{minionName} – {minionAge} years old");
        }
    }
}
