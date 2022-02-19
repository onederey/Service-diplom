CREATE TABLE [dbo].[ServiceTasks] (
	[TaskID]			INT				PRIMARY KEY,
	[TaskType]			INT				FOREIGN KEY REFERENCES [dbo].[TaskTypes] ([Id]),
	[Branch]			INT				FOREIGN KEY REFERENCES [dbo].[Branches] ([BranchCode]),
	[TaskName]			NVARCHAR(50)	NOT NULL,
	[LastWorkTime]		DATETIME		NULL,
	[TaskStartTime]		DATETIME		NOT NULL,
	[TaskEndTime]		DATETIME		NOT NULL,
	
	[FilePath]			NVARCHAR(50)	NULL,
	[FieldsCount]		INT				NULL,
	[FieldsSeparator]	NVARCHAR(5)		NULL,

	[ModifiedBy]		NVARCHAR(50)	NOT NULL,
	[AuthoriziedBy]		NVARCHAR(50)	NOT NULL,
	[Description]		NVARCHAR(250)	NULL
)
GO