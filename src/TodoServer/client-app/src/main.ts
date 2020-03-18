import Vue from "vue"
import Vuex from "vuex"
import store from "./store"

Vue.use(Vuex)


import Calendar from 'v-calendar/lib/components/calendar.umd'
import DatePicker from 'v-calendar/lib/components/date-picker.umd'

// Register components in your 'main.js'
Vue.component('calendar', Calendar)
Vue.component('date-picker', DatePicker)

const App = () => import(/* webpackChunkName: "launcher" */ "./components/app.vue")

new Vue({
  render: h => h(App),
  store: store
}).$mount("#app")
