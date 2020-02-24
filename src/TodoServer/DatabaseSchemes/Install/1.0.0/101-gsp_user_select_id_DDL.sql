CREATE PROCEDURE [gsp_user_select_id] (
  @vcUid VARCHAR(32)
  ,@iId BIGINT OUT
)
AS BEGIN
  
  SET NOCOUNT ON
  
  SET @iId = (
    SELECT 
      [id]
    FROM
      [user]
    WHERE
      [uid] = @vcUid  --INDEX [ui_user$uid]
  )
  
END
GO

