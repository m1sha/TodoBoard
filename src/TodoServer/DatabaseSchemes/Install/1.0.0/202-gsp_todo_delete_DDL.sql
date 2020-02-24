
IF OBJECT_ID(N'gsp_todo_delete') IS NOT NULL
  DROP PROCEDURE [gsp_todo_delete]
GO

CREATE PROCEDURE [gsp_todo_delete] (
  @vcUid VARCHAR(32)
)
AS BEGIN
  
  SET NOCOUNT ON
  
  DELETE FROM 
    [todo]
  WHERE 
    [uid] = @vcUid
  
END
GO

