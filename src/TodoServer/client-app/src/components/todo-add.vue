<template>
  <div>
    <div class="tabs">
        <a class="tab-item" href="#" :class="{selected: selectedTab===1}" @click.prevent="selectedTab = 1">Info</a>
        <a class="tab-item" href="#" :class="{selected: selectedTab===2}" @click.prevent="selectedTab = 2">Description</a>
    </div>
    <div v-show="selectedTab===1" class="form">
      <label>Todo title</label>
      <input type="text" class="input-control" :class="{error: !isTitleValid }" v-model="todo.title" @input="checkValid('title')" />
      
    
      <label>Status</label>
      <select2 v-model="todo.status"  :items="[{id: 1, name:'New'}, {id: 2, name:'In work'}, {id: 3, name:'Finished'}]" type="number" />
      <label>Created by</label>
      <select2 v-model="todo.createByUser.id"  :items="users" />
      <label>Assign to</label>
      <select2 v-model="todo.assignToUser.id"  :items="users" />
      <label>Plan date</label>
  
      <date-picker  v-model='selectedDate' :input-props='{ class:"input-control"}' />
    </div>
    <div v-show="selectedTab===2" class="form">
      
      <textarea class="textarea-control" :class="{error: !isMessageValid }" v-model="todo.message" @input="checkValid('message')"></textarea>
      <label>Markdown syntax supported</label>
    </div>
  </div>
</template>
<style lang="scss">
@import "@/assets/_form.scss";
@import "@/assets/_tabs.scss";

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
      selectedTab: 1
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