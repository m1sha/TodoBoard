<template>
<div>
  <div v-for="(item, index) in items" :key="index">
    {{item.title }}
    <p>{{item.message}}</p>
  </div>

  <float-button showAddBtn="true" @add="openAddTodoDialog" />
  <todo-add-dialog v-if="showAddDialog" v-model="showAddDialog" :title="dialogTitle" @accept="addTodo" />
</div>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapGetters, mapActions } from 'vuex'
import Actions from '@/store/actions'
import FloatButton from "./common/float-button.vue"
import TodoAddDialog from "./todo-add-dialog.vue"
import { TodoItem } from '../entities/todo-item'

export default Vue.extend({
  data() {
      return {
        showAddDialog : false,
        dialogTitle: ""
      }
  },
  methods:{
    openAddTodoDialog(){
      this.dialogTitle = "Create new ToDo"
      this.showAddDialog = true
    },
    addTodo(item: TodoItem){
      this[Actions.TodoAdd](item)
    },
    ...mapActions([
      Actions.TodoList,
      Actions.TodoAdd
    ])
  },
  computed:{
    ...mapGetters([
      'items',
      'filter'
    ])
  },
  mounted(){
    this[Actions.TodoList]()
  },
  components: {
    "float-button": FloatButton,
    "todo-add-dialog": TodoAddDialog
  }
})
</script>