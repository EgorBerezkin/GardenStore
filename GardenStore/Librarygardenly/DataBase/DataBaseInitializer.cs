using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Librarygardenly.DataBase
{
    public class DataBaseInitializer
    {
        private string serverConnectionString = "Host=localhost;Username=postgres";
        private string databaseConnectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";

        public void Initialize()
        {
            CreateDatabaseIfNotExists();
            if (!DatabaseHasTables())
            {
                RestoreDatabase();
            }
        }

        private void CreateDatabaseIfNotExists()
        {
            using (var connection = new NpgsqlConnection(serverConnectionString))
            {
                connection.Open();
                string sql = @"SELECT COUNT(*)
                    FROM pg_database 
                    WHERE datname = 'GardenlyDB'";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    int databaseCount = Convert.ToInt32(command.ExecuteScalar());
                    if (databaseCount == 0)
                    {
                        command.CommandText = "CREATE DATABASE \"GardenlyDB\"";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool DatabaseHasTables()
        {
            using (var connection = new NpgsqlConnection(databaseConnectionString))
            {
                connection.Open();

                string sql = @"SELECT EXISTS (
                    SELECT 1
                    FROM information_schema.tables
                    WHERE table_schema = 'public'
                    AND table_name = 'users'
                )";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    return (bool)command.ExecuteScalar();
                }
            }
        }

        private void RestoreDatabase()
        {
            string sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "GardenlyDB.sql");

            if (!File.Exists(sqlFilePath))
            {
                throw new FileNotFoundException("Не найден файл базы данных:\n" + sqlFilePath);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = FindPsql();
            startInfo.Arguments ="-U postgres -d GardenlyDB -f \"" + sqlFilePath + "\"";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    throw new Exception("Не удалось восстановить базу данных.\n\n" +error);
                }
            }
        }
        private string FindPsql()
        {
            string[] possiblePaths =
            {
                @"C:\Program Files\PostgreSQL\18\bin\psql.exe",
                @"C:\Program Files\PostgreSQL\17\bin\psql.exe",
                @"C:\Program Files\PostgreSQL\16\bin\psql.exe",
                @"C:\Program Files\PostgreSQL\15\bin\psql.exe",
                @"C:\Program Files\PostgreSQL\14\bin\psql.exe",
                @"C:\Program Files\PostgreSQL\13\bin\psql.exe"
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }
            throw new FileNotFoundException("Не найден файл psql.exe. " + "Проверьте, установлен ли PostgreSQL.");
        }
    }
}
