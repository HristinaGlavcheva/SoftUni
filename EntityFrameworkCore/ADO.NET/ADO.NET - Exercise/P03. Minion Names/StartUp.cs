using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Text;

namespace _P03._Minion_Names
{
    class StartUp
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            
            sqlConnection.Open();
            
            int villainId = int.Parse(Console.ReadLine());
            
            StringBuilder sb = new StringBuilder();
            
            string getVillainNameQuery = "SELECT [Name] FROM Villains " +
                                            "WHERE Id = @villainId";
            
            using SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, sqlConnection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);

            string villainName = getVillainNameCommand.ExecuteScalar()?.ToString();
            
            if (villainName == null)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villainName}");
            }

            string getMinionsInfoQuery = "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNumber, m.[Name], m.Age " +
                                         "FROM Villains v " +
                                         "LEFT JOIN MinionsVillains mv ON mv.VillainId = v.Id " +
                                         "LEFT JOIN Minions m ON m.Id = mv.MinionId " +
                                         "WHERE v.Id = @villainId " +
                                         "ORDER BY m.[Name]";

            using SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQuery, sqlConnection);
            getMinionsInfoCommand.Parameters.AddWithValue("@villainId", villainId);

            using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

            while (reader.Read())
            {
                int rowNumber = (int)(long)reader["RowNumber"];
                string minionName = (string)reader["Name"]?.ToString();
                string minionAge = reader["Age"]?.ToString();

                if (minionName == "")
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
