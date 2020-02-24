CREATE PROCEDURE [gsp_user_select]
AS BEGIN
  
  SET NOCOUNT ON
  
  SELECT 
    [uid]
    ,[name]
  FROM
    [user]
  
END
GO

