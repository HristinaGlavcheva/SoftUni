using Microsoft.Data.SqlClient;
using System;
using System.Data.Common;

namespace ADO.NET___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //. е едно и също с:
            //localhost 
            //127.0.0.1
            //DESKTOP-B209R4Q - адресът на компютъра

            string connectionString = "Server=.;Database=SoftUni;Integrated Security=true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string command = "SELECT COUNT(*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                object result = sqlCommand.ExecuteScalar();
                //int? result = sqlCommand.ExecuteScalar() as int?; aко знаем какъв обект връща можем директно да си го кастнем така
                // Или така: int result = (int)sqlCommand.ExecuteScalar();
                // конвертиране чрез as .... ако не може да конвертира връща null, a по другия начин ако не може да конвертира гърми с ексепшън
                Console.WriteLine(result);

                SqlCommand sqlCommand1 = new SqlCommand("SELECT FirstName, LastName, Salary FROM Employees WHERE FirstName LIKE ('N%')", sqlConnection);
                using (SqlDataReader reader = sqlCommand1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string firstName = (string)reader[0];
                        //string lastName = (string)reader[1];
                        //Console.WriteLine(firstName + " " + lastName);

                        //По-правиният начин е:     (не е нужно да знаем точния ред и индекси)
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];
                        Console.WriteLine(firstName + " " + lastName + " => " + salary);
                    }
                }
                

                SqlCommand updateSalaryCommand = new SqlCommand("UPDATE Employees SET Salary *= 1.1", sqlConnection);
                int updatedRows = updateSalaryCommand.ExecuteNonQuery();
                Console.WriteLine($"Salary updated for {updatedRows} employees");

                using (SqlDataReader reader2 = sqlCommand1.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        string firstName = (string)reader2["FirstName"];
                        string lastName = (string)reader2["LastName"];
                        decimal salary = (decimal)reader2["Salary"];
                        Console.WriteLine(firstName + " " + lastName + " => " + salary);
                    }
                }
            }

            //P01 from the Exercise---------------------------------------------------------------------------------------

            string connectionStringCreateAndPopulateTables = "Server=.; Database=MinionsDB; Integrated Security = true";
            using (SqlConnection sqlConnectionCreateAndPopulateTables = new SqlConnection(connectionStringCreateAndPopulateTables))
            {
                sqlConnectionCreateAndPopulateTables.Open();

                string createTableCountriesQuery = "CREATE TABLE Countries" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50))";
                createAndPopulateTable(createTableCountriesQuery, sqlConnectionCreateAndPopulateTables);

                string createTableTownsQuery = "CREATE TABLE Towns" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50)," +
                                                        "CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
                createAndPopulateTable(createTableTownsQuery, sqlConnectionCreateAndPopulateTables);

                string createTableMinionsQuery = "CREATE TABLE Minions" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(30)," +
                                                        "Age INT," +
                                                        "TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                createAndPopulateTable(createTableMinionsQuery, sqlConnectionCreateAndPopulateTables);

                string createTableEvilnessFactorsQuery = "CREATE TABLE EvilnessFactors" +
                                                                "(Id INT PRIMARY KEY IDENTITY," +
                                                                "Name VARCHAR(50))";
                createAndPopulateTable(createTableEvilnessFactorsQuery, sqlConnectionCreateAndPopulateTables);

                string createTableVillainsQuery = "CREATE TABLE Villains" +
                                                        "(Id INT PRIMARY KEY IDENTITY," +
                                                        "Name VARCHAR(50)," +
                                                        "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                createAndPopulateTable(createTableVillainsQuery, sqlConnectionCreateAndPopulateTables);

                string createTableMinionsVillainsQuery = "CREATE TABLE MinionsVillains" +
                                                                "(MinionId INT FOREIGN KEY REFERENCES Minions(Id)," +
                                                                "VillainId INT FOREIGN KEY REFERENCES Villains(Id)," +
                                                                "CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
                createAndPopulateTable(createTableMinionsVillainsQuery, sqlConnectionCreateAndPopulateTables);

                string insertIntoTableCountriesQuery = "INSERT INTO Countries ([Name]) " +
                                                        "VALUES " +
                                                        "('Bulgaria')," +
                                                        "('England')," +
                                                        "('Cyprus')," +
                                                        "('Germany')," +
                                                        "('Norway')";
                createAndPopulateTable(insertIntoTableCountriesQuery, sqlConnectionCreateAndPopulateTables);

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
                createAndPopulateTable(insertIntoTableTownsQuery, sqlConnectionCreateAndPopulateTables);

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
                createAndPopulateTable(insertIntoTableMinionsQuery, sqlConnectionCreateAndPopulateTables);

                string insertIntoTableEvilnessFactorsQuery = "INSERT INTO EvilnessFactors (Name) " +
                                                                "VALUES" +
                                                                "('Super good')," +
                                                                "('Good')," +
                                                                "('Bad')," +
                                                                "('Evil')," +
                                                                "('Super evil')";
                createAndPopulateTable(insertIntoTableEvilnessFactorsQuery, sqlConnectionCreateAndPopulateTables);

                string insertIntoTableVillainsQuery = "INSERT INTO Villains (Name, EvilnessFactorId) " +
                                                            "VALUES " +
                                                            "('Gru',2)," +
                                                            "('Victor',1)," +
                                                            "('Jilly',3)," +
                                                            "('Miro',4)," +
                                                            "('Rosen',5)," +
                                                            "('Dimityr',1)," +
                                                            "('Dobromir',2)";
                createAndPopulateTable(insertIntoTableVillainsQuery, sqlConnectionCreateAndPopulateTables);

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
                createAndPopulateTable(insertIntoTableMinionsVillainsQuery, sqlConnectionCreateAndPopulateTables);
            }
        }

        private static void createAndPopulateTable(string createAndPopulateTableQuery, SqlConnection sqlConnectionCreateAndPopulateTables)
        {
            SqlCommand createAndPopulateTableCommand = new SqlCommand(createAndPopulateTableQuery, sqlConnectionCreateAndPopulateTables);
            createAndPopulateTableCommand.ExecuteNonQuery();
        }
    }
}
