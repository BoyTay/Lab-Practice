using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AsyncSocketTCP
{
    internal class AccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string must be provided", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task InitializeAsync()
        {
            const string ensureTableSql = @"
            IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
            BEGIN
                IF COL_LENGTH('dbo.Users', 'PasswordHash') IS NOT NULL 
                AND COL_LENGTH('dbo.Users', 'Password') IS NULL
                BEGIN
                    EXEC sp_rename 'dbo.Users.PasswordHash', 'Password', 'COLUMN';
                END
            END

            IF OBJECT_ID('dbo.Users', 'U') IS NULL
            BEGIN
                CREATE TABLE dbo.Users
                (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Username NVARCHAR(100) NOT NULL UNIQUE,
                    Password NVARCHAR(256) NOT NULL,
                    CreatedAt DATETIME2 NOT NULL 
                        CONSTRAINT DF_Users_CreatedAt DEFAULT (SYSDATETIME())
                );
            END";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(ensureTableSql, connection))
            {
                await connection.OpenAsync().ConfigureAwait(false);
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            const string insertSql = "INSERT INTO dbo.Users (Username, Password) VALUES (@username, @password)";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@username", username.Trim());
                    command.Parameters.AddWithValue("@password", password);

                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                return true;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Duplicate username
                return false;
            }
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            const string querySql = "SELECT Password FROM dbo.Users WHERE Username = @username";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(querySql, connection))
            {
                command.Parameters.AddWithValue("@username", username.Trim());

                await connection.OpenAsync().ConfigureAwait(false);
                var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                if (result == null || result == DBNull.Value)
                {
                    return false;
                }

                string storedPassword = Convert.ToString(result);
                return string.Equals(storedPassword, password, StringComparison.Ordinal);
            }
        }

        public async Task<int> GetTotalAccountCountAsync()
        {
            const string countSql = "SELECT COUNT(*) FROM dbo.Users";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(countSql, connection))
            {
                await connection.OpenAsync().ConfigureAwait(false);
                var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(result);
            }
        }
    }
}
