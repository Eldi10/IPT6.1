using System;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        // EXAKT deine DB
        string path = @"C:\Code\IPT6.1\BD-C-sharp-connection\Schule.db";
        string connectionString = $"Data Source={path}";

        using var con = new SqliteConnection(connectionString);
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT id, name FROM users;";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);      // id = INTEGER
            string name = reader.GetString(1); // name = TEXT

            Console.WriteLine($"{id} | {name}");
        }

        Console.WriteLine("Fertig!");
        Console.ReadLine();
    }
}
