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

