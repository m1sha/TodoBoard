<template>
  <modal-dialog v-if="showDialog">
    <template slot="head">
      <h3>ToDo Detail</h3>
    </template>
    <template slot="body">
      <todo-detail v-model="localTodo" />
    </template>
    <template slot="footer">
      <div class="wb-modal-dialog-button wb-modal-dialog-button-right">
        <button class="btn btn-outline-secondary" @click="onCancel()">Закрыть</button>
      </div>
    </template>
  </modal-dialog>
</template>
<script lang="ts">
import Vue from 'vue'
import ModalDialog from "@/components/common/modal-dialog.vue"
import { TodoItem } from '@/entities/todo-item'
import TodoDetail from './todo-detail.vue'
export default Vue.extend({
   props: { 
     showDialog : Boolean, 
     todo: TodoItem 
   },
   model: {
     prop: "showDialog",
     event: "change-showDialog"
   },
   data(){
     return{
       localTodo: new TodoItem()
     }
   },
   methods:{
     onCancel() {
       this.$emit("change-showDialog", false)
       this.$emit("cancel");
     }
   },
   created(){
      if (this.todo) 
        this.localTodo = { ...this.todo }
   },
   components:{
     "modal-dialog": ModalDialog,
     "todo-detail": TodoDetail
   }
})
</script>