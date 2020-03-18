IF DB_ID('__DBNAME__') IS NOT NULL SET NOEXEC ON

CREATE DATABASE __DBNAME__
GO

USE __DBNAME__
GO

CREATE TABLE [user] (
  [id] BIGINT IDENTITY(1, 1) NOT NULL,      
    CONSTRAINT [pk_user$id] 
      PRIMARY KEY ([id]),
  
  [uid] VARCHAR(32) NOT NULL,             
    CONSTRAINT [ui_user$uid]
      UNIQUE ([uid]),

  [name] NVARCHAR(64) NOT NULL,             
    CONSTRAINT [ui_user$name]
      UNIQUE ([name]),  
  
  [create_date] DATETIME NOT NULL            
    CONSTRAINT [df_user$create_date] 
      DEFAULT(GETDATE())
    
) ON [PRIMARY]
GO

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

CREATE TABLE [todo] (
  [id] BIGINT IDENTITY(1, 1) NOT NULL,      
    CONSTRAINT [pk_todo$id] 
      PRIMARY KEY ([id]),
  
  [uid] VARCHAR(32) NOT NULL,             
    CONSTRAINT [ui_todo$uid]
      UNIQUE ([uid]),

  [title] NVARCHAR(160) NOT NULL,
  
  [text] NVARCHAR(MAX) NOT NULL,
  
  [create_date] DATETIME NOT NULL            
    CONSTRAINT [df_todo$create_date] 
      DEFAULT(GETDATE()),

  [change_date] DATETIME NOT NULL            
    CONSTRAINT [df_todo$change_date] 
      DEFAULT(GETDATE()),

  [status] INT NOT NULL 
    CONSTRAINT [df_todo$status]
      DEFAULT(1),
  
  [user_creator_id] BIGINT NOT NULL,
    CONSTRAINT [fk_todo$user_creator_id]
      FOREIGN KEY ([user_creator_id]) REFERENCES [user] ([id])
      ON UPDATE NO ACTION ON DELETE NO ACTION,

  [user_assign_id] BIGINT NOT NULL,
    CONSTRAINT [fk_todo$user_assign_id]
      FOREIGN KEY ([user_assign_id]) REFERENCES [user] ([id])
      ON UPDATE NO ACTION ON DELETE NO ACTION
    
) ON [PRIMARY]
GO


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

IF OBJECT_ID('vw_todo', 'V') IS NOT NULL BEGIN
  DROP VIEW [vw_todo]
END
GO

CREATE VIEW [vw_todo]
AS
SELECT
  t.uid
  ,t.title
  ,t.text
  ,t.create_date
  ,t.change_date
  ,t.status
  ,uc.uid  'user_creator_uid'
  ,uc.name 'user_creator_name'
  ,ua.uid  'user_assign_uid'
  ,ua.name 'user_assign_name'
FROM
  [todo] t
INNER JOIN [user] uc ON uc.id = t.user_creator_id
INNER JOIN [user] ua ON ua.id = t.user_assign_id

GO

CREATE PROCEDURE [gsp_todo_select]
AS BEGIN
  
  SET NOCOUNT ON
  
  SELECT 
    *
  FROM
    [vw_todo]
      
END
GO

EXEC gsp_user_insert '78d1aa3a3de147a6aaa9f7777c7bc071', 'Jar Jar Binks'
EXEC gsp_user_insert '55d506f2e87148e3a4ee8207e7592fc0', 'Mace Windu'
EXEC gsp_user_insert 'b0ddbbf531154ff0a796fcc9c7abd50e', 'Wicket'
EXEC gsp_user_insert 'de1fd5fb521749d285768677e40ef73b', 'Porg'
EXEC gsp_user_insert 'f8aa332732c449e9852129fb4b99ec82', 'K-2SO'
EXEC gsp_user_insert 'f11dbe85358447569ae1505bfdd247e3', 'C-3PO'
EXEC gsp_user_insert 'd2c6247a924f4672a31e62f9a92ed29c', 'Bail Organa'
EXEC gsp_user_insert 'cdced83cd1874b92bb8266c3451382fb', 'Jyn Erso'
EXEC gsp_user_insert '51766f96b6ea4011b12b8a9305cf92a8', 'Nien Nunb'
EXEC gsp_user_insert '0c3283f5eaad4e059a9e6fab343af39c', 'BB-8'
EXEC gsp_user_insert 'c69d51dfbe064c85b69431091987ef1d', 'Chewbacca'
EXEC gsp_user_insert '931bfa60f24f47828779f3f1662d36f3', 'R2-D2'

EXEC gsp_todo_insert '58d1aa3a3de147a6aff9f77ddc7bc070'
     ,'Some todo title',
     '* Task 1... * Task 2... *task 3..'
     ,1
     ,'55d506f2e87148e3a4ee8207e7592fc0'
     ,'b0ddbbf531154ff0a796fcc9c7abd50e'

EXEC gsp_todo_insert 'aaadbe85358447569ae1505bfdd2cc45'
     ,'Next todo title'
     ,'* Task 1... * Task 2...' 
     ,2
     ,'55d506f2e87148e3a4ee8207e7592fc0'
     ,'f11dbe85358447569ae1505bfdd247e3'
 
EXEC gsp_todo_insert 'f88283f5eaad4f059a9e6fab343aee09'
     ,'FF AA 1D'
     ,'* AF DD C0... * CC 09 15...' 
     ,3
     ,'0c3283f5eaad4e059a9e6fab343af39c'
     ,'931bfa60f24f47828779f3f1662d36f3'


SET NOEXEC OFF

