CREATE TABLE [dbo].[Branches] (
	[BranchCode] INT PRIMARY KEY,
	[BranchName] NVARCHAR(4) NOT NULL,
	[BankName] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(250) NULL
)
GO