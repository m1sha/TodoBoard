<template>
<div>
  <div v-for="(item, index) in todos" :key="index">
    <todo-item :item="item" @select="openSelectTodoDialog" @edit="openEditTodoDialog" @remove="openRemoveTodoDialog" />
  </div>

  <float-button showAddBtn="true" @add="openAddTodoDialog" />
  <todo-add-dialog v-if="showAddDialog" v-model="showAddDialog" :title="dialogTitle" :todo="currentTodo" @accept="addTodo" />
  <todo-remove-dialog v-if="showRemoveDialog" v-model="showRemoveDialog"  :todo="currentTodo" @accept="removeTodo" />
  <todo-detail-dialog v-if="showDetailDialog" v-model="showDetailDialog"  :todo="currentTodo" />
</div>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapGetters, mapActions } from 'vuex'
import Actions from '@/store/actions'
import FloatButton from "./common/float-button.vue"
import TodoItemView from "./todo-item-view.vue"
import TodoAddDialog from "./todo-add-dialog.vue"
import TodoRemoveDialog from "./todo-remove-dialog.vue"
import TodoDetailDialog from "./todo-detail-dialog.vue"
import { TodoItem } from '../entities/todo-item'

export default Vue.extend({
  data() {
      return {
        showAddDialog : false,
        showRemoveDialog : false,
        showDetailDialog : false,
        dialogTitle: "",
        currentTodo: new TodoItem()
      }
  },
  methods:{
    openAddTodoDialog(){
      this.dialogTitle = "Create new ToDo"
      this.currentTodo = new TodoItem()
      this.showAddDialog = true
    },

    openEditTodoDialog(item: TodoItem){
       this.dialogTitle = "Edit ToDo"
       this.currentTodo = item
       this.showAddDialog = true
    },

    openRemoveTodoDialog(item: TodoItem){
       this.currentTodo = item
       this.showRemoveDialog = true
    },

    openSelectTodoDialog(item: TodoItem){
       
       this.currentTodo = item
       this.showDetailDialog = true
    },

    async addTodo(item: TodoItem){
      await this[Actions.TodoAdd](item)
      await this[Actions.TodoList]()
    },

    async removeTodo(item: TodoItem){
      await this[Actions.TodoRemove](item)
      await this[Actions.TodoList]()
    },
    ...mapActions([
      Actions.TodoList,
      Actions.TodoAdd,
      Actions.TodoRemove
    ])
  },
  computed:{
    ...mapGetters([
      'todos',
      'filter'
    ])
  },
  mounted(){
    this[Actions.TodoList]()
  },
  components: {
    "todo-item": TodoItemView,
    "float-button": FloatButton,
    "todo-add-dialog": TodoAddDialog,
    "todo-remove-dialog": TodoRemoveDialog,
    "todo-detail-dialog": TodoDetailDialog
  }
})
</script>