import Vue from "vue";
import Vuex from "vuex"
Vue.use(Vuex);
import TodoModule from "./todo-module"
import UserModule from "./user-module"

const store = new Vuex.Store({
  modules:{
    todo: TodoModule,
    user: UserModule
  }
})

export default store