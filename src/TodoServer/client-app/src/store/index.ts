import Vue from "vue";
import Vuex from "vuex"
Vue.use(Vuex);
import TodoModule from "./todo-module"
import UserModule from "./user-module"
import TodoListBroadcast from '@/broadcasts/todo-list-broadcast'
const store = new Vuex.Store({
  modules:{
    todo: TodoModule,
    user: UserModule
  }
})

store["todoListBroadcast"] = new TodoListBroadcast(store)

export default store