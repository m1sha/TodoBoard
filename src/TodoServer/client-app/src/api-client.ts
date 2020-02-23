import axios from 'axios'
import { TodoFilter } from './entities/todo-filter'
import { TodoItem } from './entities/todo-item'

const routes = {
  TODO_LIST : "Todo/List",
  TODO_ADD : "Todo/Add"
}

export default class ApiClient {
  static todo = class name {
    
    static getTodoList(filter: TodoFilter){
      return axios.post(routes.TODO_LIST, filter)
    }
    static addTodo(item: TodoItem) {
      return axios.post(routes.TODO_ADD, item)
    }
  }
}