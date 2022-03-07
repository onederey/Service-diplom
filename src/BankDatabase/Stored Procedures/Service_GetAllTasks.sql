CREATE PROCEDURE [dbo].[Service_GetAllTasks]
AS
BEGIN
	SELECT 
		TaskID
		,TaskType
		,Branch
		,TaskName
		,Dependency
		,LastWorkTime
		,TaskStartTime
		,TaskEndTime
		,FilePath
		,FieldsCount
		,FieldsSeparator
	FROM
		[dbo].[ServiceTasks]
END