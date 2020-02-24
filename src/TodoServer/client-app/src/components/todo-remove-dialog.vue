<template>
  <modal-dialog v-if="showDialog">
    <template slot="head">
      <h3>Remove ToDo?</h3>
    </template>
    <template slot="body">
      <p>Remove "{{localTodo.title}}"</p>
      
    </template>
    <template slot="footer">

      <div class="wb-modal-dialog-button wb-modal-dialog-button-right">
        <button class="btn btn-outline-success wb-md-button" @click="onAccept()">OK</button>
        <button class="btn btn-outline-secondary wb-md-button" @click="onCancel()">Закрыть</button>
      </div>

    </template>
  </modal-dialog>
</template>
<script lang="ts">
import Vue from 'vue'
import ModalDialog from "@/components/common/modal-dialog.vue"

import { TodoItem } from '@/entities/todo-item'
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
   methods: {
     onAccept() {
       this.$emit("change-showDialog", false)
       this.$emit("accept", this.localTodo);
     },
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
   }
})
</script>