
IF OBJECT_ID(N'gsp_todo_insert') IS NOT NULL
  DROP PROCEDURE [gsp_todo_insert]
GO

CREATE PROCEDURE [gsp_todo_insert] (
  @vcUid VARCHAR(32)
  ,@nvTitle NVARCHAR(160)
  ,@nvText NVARCHAR(MAX)
  ,@iStatus INT
  ,@vcUserCreatorUid VARCHAR(32)
  ,@vcUserAssignUid VARCHAR(32)
)
AS BEGIN
  
  SET NOCOUNT ON
  
  DECLARE @iUserCreatorId BIGINT
  EXEC [gsp_user_select_id] @vcUserCreatorUid, @iUserCreatorId OUT
  
  DECLARE @iUserAssignId BIGINT
  EXEC [gsp_user_select_id] @vcUserAssignUid, @iUserAssignId OUT
  
  DECLARE @iTodoId BIGINT
  SET @iTodoId = (
    SELECT
      [id]
    FROM
      [todo]
    WHERE
      [uid] = @vcUid
  )

  IF @iTodoId IS NULL BEGIN
    INSERT INTO [todo](
      [uid]
      ,[title]
      ,[text]
      ,[status]
      ,[user_creator_id]
      ,[user_assign_id]
    ) VALUES(
      @vcUid
      ,@nvTitle
      ,@nvText
      ,@iStatus
      ,@iUserCreatorId
      ,@iUserAssignId
    )
  END ELSE BEGIN
    UPDATE
      [todo]
    SET
      [title]           = @nvTitle
      ,[text]            = @nvText
      ,[status]          = @iStatus
      ,[user_creator_id] = @iUserCreatorId
      ,[user_assign_id]  = @iUserAssignId
      ,[change_date]     = GETDATE()
    WHERE
      [id] = @iTodoId
  END
  
END
GO

