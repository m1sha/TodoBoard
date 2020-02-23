<template>
  <modal-dialog v-if="showDialog">
    <template slot="head">
      <h3> {{title}}</h3>
    </template>
    <template slot="body">
      <todo-add v-model="localTodo"/>
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
import TodoAdd from "./todo-add.vue"
import { TodoItem } from '@/entities/todo-item'
export default Vue.extend({
   props: { 
     showDialog : Boolean, 
     title: String, 
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
     "todo-add": TodoAdd
   }
})
</script>