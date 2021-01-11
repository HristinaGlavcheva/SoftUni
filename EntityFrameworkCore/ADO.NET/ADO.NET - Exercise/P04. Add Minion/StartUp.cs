using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using System.Text;

namespace P04._Add_Minion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTownName = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split();

            string villainName = villainInfo[1];

            StringBuilder sb = new StringBuilder();

            string connectionString = "Server=.; Database=MinionsDB; Integrated Security=true;";

            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string checkTownCmdText = "SELECT Name FROM Towns WHERE Name = @minionTownName ";
            using SqlCommand checkTownCmd = new SqlCommand(checkTownCmdText, sqlConnection);
            checkTownCmd.Parameters.AddWithValue("@minionTownName", minionTownName);
            var resultTownNameCheck = checkTownCmd.ExecuteScalar();

            if(resultTownNameCheck == null)
            {
                string addTownCmdText = "INSERT INTO Towns([Name]) VALUES (@minionTownName)";
                using SqlCommand addTownCmd = new SqlCommand(addTownCmdText, sqlConnection);
                addTownCmd.Parameters.AddWithValue("@minionTownName", minionTownName);
                addTownCmd.ExecuteNonQuery();
                sb.AppendLine($"Town {minionTownName} was added to the database.");
            }

            string checkVillainCmdText = "SELECT Name FROM Villains WHERE Name = @villainName";
            using SqlCommand checkVillainCmd = new SqlCommand(checkVillainCmdText, sqlConnection);
            checkVillainCmd.Parameters.AddWithValue("@villainName", villainName);
            var resultVillainNameCheck = checkVillainCmd.ExecuteScalar();

            if (resultVillainNameCheck == null)
            {
                string addVillainCmdText = "INSERT INTO Villains(Name, EvilnessFactorId) VALUES (@villainName, 4)";
                using SqlCommand addVillainCmd = new SqlCommand(addVillainCmdText, sqlConnection);
                addVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                addVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            string getTownIdCmdText = "SELECT Id FROM Towns WHERE Name = @minionTownName";
            using SqlCommand getTownId = new SqlCommand(getTownIdCmdText, sqlConnection);
            getTownId.Parameters.AddWithValue("@minionTownName", minionTownName);
            int townId = (int)getTownId.ExecuteScalar();

            string addMinionCmdText = "INSERT INTO Minions(Name, Age, TownId) VALUES(@minionName, @minionAge, @townId)";
            using SqlCommand addMinion = new SqlCommand(addMinionCmdText, sqlConnection);
            addMinion.Parameters.AddWithValue("@minionName", minionName);
            addMinion.Parameters.AddWithValue("@minionAge", minionAge);
            addMinion.Parameters.AddWithValue("@townId", townId);
            addMinion.ExecuteNonQuery();

            string getMinionIdCmdText = "SELECT Id FROM Minions WHERE Name = @minionName";
            using SqlCommand getMinionId = new SqlCommand(getMinionIdCmdText, sqlConnection);
            getMinionId.Parameters.AddWithValue("@minionName", minionName);
            int minionId = (int)getMinionId.ExecuteScalar();

            string getVillainIdCmdText = "SELECT Id FROM Villains WHERE Name = @villainName";
            using SqlCommand getVillainId = new SqlCommand(getVillainIdCmdText, sqlConnection);
            getVillainId.Parameters.AddWithValue("@villainName", villainName);
            int villainId = (int)getVillainId.ExecuteScalar();

            string setMinionAsServantOfVillainCmdText = "INSERT INTO MinionsVillains VALUES(@minionId, @villainId)";
            using SqlCommand setMinionAsServantOfVillainCmd = new SqlCommand(setMinionAsServantOfVillainCmdText, sqlConnection);
            setMinionAsServantOfVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            setMinionAsServantOfVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            setMinionAsServantOfVillainCmd.ExecuteNonQuery();
            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
