CREATE TABLE [dbo].[TaskTypes] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Type] NVARCHAR(20) UNIQUE NOT NULL
)
GO