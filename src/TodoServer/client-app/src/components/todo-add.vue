<template>
  <div class="form">
    <label>Todo title</label>
    <input type="text" class="input-control" v-model="todo.title" />
    <label>Todo text</label>
    <textarea class="textarea-control" v-model="todo.message"></textarea>
    <label>Status</label>
    <select2 />
  </div>
</template>
<style lang="scss">
@import "@/assets/_form.scss";
</style>
<script lang="ts">
import Vue from 'vue'
import Select2 from "./common/select2.vue"
import { TodoItem } from '@/entities/todo-item'

export default Vue.extend({
   props:{
     todo: TodoItem
   },
   model: {
     prop: "todo",
     event: "change-todo"
   },

  

  components:{
    "select2": Select2
  }
})
</script>