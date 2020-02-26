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

  [type] INT NOT NULL 
    CONSTRAINT [df_todo$type]
      DEFAULT(1),

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

