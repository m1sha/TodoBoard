import axios from 'axios'
import { TodoFilter } from './entities/todo-filter'
import { TodoItem } from './entities/todo-item'
import { UserFilter } from './entities/user-filter'

const routes = {
  TODO_LIST : "Todo/List",
  TODO_ADD : "Todo/Add",
  TODO_REMOVE : "Todo/Remove",
  USER_LIST : "User/List"
}

export default class ApiClient {
  static todo = class {
    
    static getTodoList(filter: TodoFilter){
      return axios.post(routes.TODO_LIST, filter)
    }
    static addTodo(item: TodoItem) {
      return axios.post(routes.TODO_ADD, item)
    }
    static removeTodo(uids: Array<string>) {
      return axios.post(routes.TODO_REMOVE, uids)
    }
  }

  static user = class {
    
    static getUserList(filter: UserFilter){
      return axios.post(routes.USER_LIST, filter)
    }
    
  }
}