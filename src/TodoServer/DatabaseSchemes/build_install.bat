copy /b ^
.\install\install_start.sql+^
.\install\1.0.0\100-user_DDL.sql+^
.\install\1.0.0\101-gsp_user_select_id_DDL.sql+^
.\install\1.0.0\102-gsp_user_select_DDL.sql+^
.\install\1.0.0\103-gsp_user_insert_DDL.sql+^
.\install\1.0.0\200-todo_DDL.sql+^
.\install\1.0.0\201-gsp_todo_insert_DDL.sql+^
.\install\1.0.0\202-gsp_todo_delete_DDL.sql+^
.\install\1.0.0\210-vw_todo_DDL.sql+^
.\install\1.0.0\211-gsp_todo_select_DDL.sql+^
.\filldata\1.0.0\10-user.sql+^
.\filldata\1.0.0\20-todo.sql+^
.\install\install_end.sql^ ^
..\wwwroot\sql\install\install.sql