import { TodoFilter } from '@/entities/todo-filter'
import { TodoItem } from '@/entities/todo-item'
import Action from './actions'
import client from "@/api-client"

var Mutations = {
  setItems: "setItems",
  setDataReceiving: "setDataReceiving",
  setDataSending: "setDataSending"
}

const TodoModule = {
  state: { 
    filter: new TodoFilter(),
    items : new Array<TodoItem>(),

    dataReceiving: false,
    dataSending: false,
  },
  mutations: { 
   [Mutations.setItems](state: any, items: Array<TodoItem>){
    state.items = items
   },
   [Mutations.setDataReceiving](state: any, value: boolean){
    state.dataReceiving = value
   },
   [Mutations.setDataSending](state: any, value: boolean){
    state.dataSending = value
   }
  },
  actions: {  
   [Action.TodoList]({commit, state}){
    commit(Mutations.setDataReceiving, true)
    client.todo.getTodoList(state.filter)
     .then(r=> {
       commit(Mutations.setItems, r.data)
       commit(Mutations.setDataReceiving, false)
      })
     .catch(e=> {
       commit(Mutations.setDataReceiving, false)
     })
      
   },
   async [Action.TodoAdd]({commit, state}, item: TodoItem){
    commit(Mutations.setDataSending, true)
    try{
      const r = await client.todo.addTodo(item);
      commit(Mutations.setDataSending, false)
    }
    catch(e){
      commit(Mutations.setDataSending, false)
    }
      
   }
  },
  getters: {
    items: state => state.items,
    filter: state => state.filter,
  }
}

export default TodoModule