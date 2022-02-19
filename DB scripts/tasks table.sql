CREATE TABLE [dbo].[ServiceTasks] (
	[TaskID]			INT				PRIMARY KEY,
	[TaskType]			INT				FOREIGN KEY REFERENCES [dbo].[TaskTypes] ([Id]),
	[Branch]			INT				FOREIGN KEY REFERENCES [dbo].[Branches] ([BranchCode]),
	[TaskName]			NVARCHAR(50)	NOT NULL,
	[LastWorkTime]		DATETIME		NULL,
	[TaskStartTime]		DATETIME		NOT NULL,
	[TaskEndTime]		DATETIME		NOT NULL,
	[Dependency]		NVARCHAR(100)	NOT NULL,
	
	[FilePath]			NVARCHAR(50)	NULL,
	[FieldsCount]		INT				NULL,
	[FieldsSeparator]	NVARCHAR(5)		NULL,

	[ModifiedBy]		NVARCHAR(50)	NOT NULL,
	[AuthoriziedBy]		NVARCHAR(50)	NOT NULL,
	[Description]		NVARCHAR(250)	NULL
)
GO



INSERT INTO [dbo].[ServiceTasks] ([TaskID],[TaskType],[Branch],[TaskName],[LastWorkTime],[TaskStartTime],[TaskEndTime],[Dependency],[FilePath],[FieldsCount],[FieldsSeparator],[ModifiedBy],[AuthoriziedBy],[Description])
VALUES(1, 1, 0, 'TestTask1', null, '2022-02-19 05:00:00', '2022-02-19 23:59:22', '', null, null, null, 'am', 'am', null)