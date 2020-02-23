import Vue from "vue";
import Vuex from "vuex"
Vue.use(Vuex);
import TodoModule from "./todo-module"

const store = new Vuex.Store({
  modules:{
    todo: TodoModule
  }
})

export default store