using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05._Change_Town_Names_Casing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            List<string> towns = new List<string>();

            string sqlConnectionString = "Server=.; Database=MinionsDB; Integrated Security=true;";

            using SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();

            string getCountryIdCmdText = "SELECT Id FROM Countries WHERE [Name] = @countryName";
            using SqlCommand getCountryIdCmd = new SqlCommand(getCountryIdCmdText, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", countryName);

            int? countryId = (int?)getCountryIdCmd.ExecuteScalar();

            if(countryId == null)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                string updateTownNamesUppercaseCmdText = "UPDATE Towns " +
                                                         "SET Name = UPPER(Name) " +
                                                         "WHERE CountryCode = @countryId";
                SqlCommand updateTownNamesUppercaseCmd = new SqlCommand(updateTownNamesUppercaseCmdText, sqlConnection);
                updateTownNamesUppercaseCmd.Parameters.AddWithValue("@countryId", countryId);
                int countUpdatedTownNames = updateTownNamesUppercaseCmd.ExecuteNonQuery();
                

                string getUpdatedTownsNamesCmdText = "SELECT Name FROM Towns WHERE CountryCode = @countryId";
                using SqlCommand getUpdatedTownsNamesCmd = new SqlCommand(getUpdatedTownsNamesCmdText, sqlConnection);
                getUpdatedTownsNamesCmd.Parameters.AddWithValue("@countryId", countryId);

                using SqlDataReader reader = getUpdatedTownsNamesCmd.ExecuteReader();

                while (reader.Read())
                {
                    string updatedTownName = (string)reader["Name"];
                    towns.Add(updatedTownName);
                }

                Console.WriteLine($"{countUpdatedTownNames} town names were affected.");
                Console.WriteLine($"[{String.Join(", ", towns)}]");
            }
        }
    }
}
