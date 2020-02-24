
IF OBJECT_ID(N'gsp_user_insert') IS NOT NULL
  DROP PROCEDURE [gsp_user_insert]
GO

CREATE PROCEDURE [gsp_user_insert] (
  @vcUid VARCHAR(32)
  ,@nvName NVARCHAR(64)
)
AS BEGIN
  
  SET NOCOUNT ON
  
  INSERT INTO [user](
    [uid]
    ,[name]
  ) VALUES(
    @vcUid
    ,@nvName
  )
  
END
GO

