
GO
IF DB_ID('AccountClient') IS NULL
BEGIN
    CREATE DATABASE AccountClient;
END
GO
USE AccountClient;
GO
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(100) NOT NULL,
        Password NVARCHAR(256) NOT NULL,
        CreatedAt DATE NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT (CAST(GETDATE() AS DATE))
    );

    CREATE UNIQUE INDEX IX_Users_Username ON dbo.Users(Username);
END
GO
