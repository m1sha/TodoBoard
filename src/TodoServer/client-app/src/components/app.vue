<template>
  <div id="app">
    <app-header />
    <div class="container">
      <main role="main" class="pb-3">

        <todo-list />
        <div style="margin-bottom:60px;"></div>
      </main>
    </div>
    <app-footer />
  </div>
</template>

<style lang="scss">
//@import "../assets/style.scss";

</style>

<script lang="ts">
import Vue from "vue";
const TodoList = () => import(/* webpackChunkName: "tdl" */ "./todo-list.vue")
const AppHeader = () => import(/* webpackChunkName: "apph" */ "./common/app-header.vue")
const AppFooter = () => import(/* webpackChunkName: "appf" */ "./common/app-footer.vue")

export default Vue.extend({
  name: "app",
  components: {
    "todo-list": TodoList,
    "app-header": AppHeader,
    "app-footer": AppFooter
  }
  
});
</script>
