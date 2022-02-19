CREATE TABLE [dbo].[Branches] (
	[BranchCode] INT PRIMARY KEY,
	[BranchName] NVARCHAR(4) NOT NULL,
	[BankName] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(250) NULL
)
GO

INSERT INTO [dbo].[Branches] (BranchCode, BranchName, BankName)
VALUES
	(0, 'RU1', 'Moscow'),
	(1, 'RU2', 'SaintPetersburg'),
	(2, 'RU3', 'Kazan'),
	(3, 'RU4', 'Izhevsk'),
	(4, 'RU5', 'Novosibirsk')