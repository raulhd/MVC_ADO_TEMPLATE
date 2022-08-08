CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [IdentificationNumber] NVARCHAR(50) NOT NULL
)
