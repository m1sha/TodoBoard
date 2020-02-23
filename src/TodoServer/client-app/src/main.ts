import Vue from "vue"
import Vuex from "vuex"
import store from "./store"

Vue.use(Vuex)

const App = () => import(/* webpackChunkName: "launcher" */ "./components/app.vue")

new Vue({
  render: h => h(App),
  store: store
}).$mount("#app")
