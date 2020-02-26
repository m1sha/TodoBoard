<template>
  <div class="form">
    <label>Todo title</label>
    <input type="text" class="input-control" :class="{error: !isTitleValid }" v-model="todo.title" @input="checkValid('title')" />
    <label>Todo text</label>
    <textarea class="textarea-control" :class="{error: !isMessageValid }" v-model="todo.message" @input="checkValid('message')"></textarea>
    <label>Type</label>
    <select2 v-model="todo.type"  :items="[{uid: 1, name:'Feature'}, {uid: 2, name:'Bug'}, {uid: 3, name:'Refactoring'}]" type="number" />
    <label>Status</label>
    <select2 v-model="todo.status"  :items="[{uid: 1, name:'New'}, {uid: 2, name:'In work'}, {uid: 3, name:'Finished'}]" type="number" />
    <label>Created by</label>
    <select2 v-model="todo.userCreator.uid"  :items="users" />
    <label>Assign to</label>
    <select2 v-model="todo.userAssign.uid"  :items="users" />
  </div>
</template>
<style lang="scss">
@import "@/assets/_form.scss";

.error{
  background-color: #fad4d4 !important;
}
</style>
<script lang="ts">
import Vue from 'vue'
import Select2 from "./common/select2.vue"
import { TodoItem } from '@/entities/todo-item'
import { mapGetters, mapActions } from 'vuex'
import Actions from '@/store/actions'

export default Vue.extend({
   props:{
     todo: TodoItem,
   },
   model: {
     prop: "todo",
     event: "change-todo"
   },
   data(){
     return {
      isTitleValid: true,
      isMessageValid: true,
     }
   },

   methods:{
     checkValid(controlName: string) {
      switch(controlName){
        case 'title': 
          this.isTitleValid = this.todo.title
          break
        case 'message': 
          this.isMessageValid = this.todo.message
          break
      }
      
      const result = this.isTitleValid && this.isMessageValid
      this.$emit('valid', result)
    },
    ...mapActions([
      Actions.UserList,
    ])
   },
   computed:{
    ...mapGetters([
      'users',
      'userFilter'
    ])
   },

   mounted(){
    this[Actions.UserList]()
   },

   components:{
    "select2": Select2
   }
})
</script>