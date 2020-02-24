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

