<template>
  <div class="todo-card">
    <div class="todo-column" style="flex:1">
      <h3> {{item.title }}</h3>
      <article class="markdown-body">
        <vue-markdown :source="item.message"></vue-markdown>
      </article>
      
      <div>
        <span class="todo-column-key">by</span>
        <span class="todo-column-value">{{ item.userCreator.name }}</span>
        <span class="todo-column-key">to</span>
        <span class="todo-column-value">{{ item.userCreator.uid === item.userAssign.uid ? "self" : item.userAssign.name }}</span>
      </div>
      <div>
        <span class="todo-column-key">created</span>
        <span class="todo-column-value" :title="createDate">{{ timeAgo.format( new Date(item.createDate)) }}</span>
        <template v-if="item.createDate!=item.changeDate">
          <span class="todo-column-key">changed</span>
          <span class="todo-column-value" :title="createDate">{{ timeAgo.format( new Date(item.changeDate)) }}</span>
        </template>
      </div>
    </div>
    <div class="todo-commands">
      <button class="btn btn-outline-secondary padding" @click="onEdit(item)"><i class="fa fa-pen"></i></button>
      <button class="btn btn-outline-secondary padding" @click="onRemove(item)"><i class="fa fa-trash"></i></button>
    </div>
    
  </div>
</template>
<style lang="scss">
@import "@/assets/_colors.scss";
@import "@/assets/github-markdown.scss";

.todo-card {
  display: flex;
  width: 100%;
  padding: 8px;
  margin: 2px;
}

.todo-column{
  display: flex;
  flex-direction: column;
}

.todo-commands{
  display: flex;
  flex-direction: row;
  align-items: flex-start;
}

.todo-commands button i {
  padding: 4px 0;
}

h3{
  color: $text-color;
  font-size: 12pt;
}

code{
  color: $text-color-second;
  padding: 4px 0;
  white-space: pre-line;
}

.padding{
  margin: 2px;
}

.todo-column-key{
 color: $text-color-second;
 font-size: 9pt;
}

.todo-column-value{
  font-size: 9pt;
  font-weight: 500;
  color: $text-color;
  padding: 0 4px;
}

</style>
<script lang="ts">
import Vue from 'vue'
import { TodoItem } from '@/entities/todo-item'
import TimeAgo from 'javascript-time-ago'
import en from 'javascript-time-ago/locale/en'
import VueMarkdown from 'vue-markdown'
export default Vue.extend({
  props:{
    item : TodoItem,
  },
  data(){
    return {
      timeAgo: null
    }
  },
  methods:{
    onEdit(item : TodoItem){
      this.$emit("edit", item)
    },
    onRemove(item : TodoItem){
      this.$emit("remove", item)
    },
    
 
  },
  computed:{
    createDate(){
      return new Date(this.item.createDate).toLocaleString()
    },
    changeDate(){
      return new Date(this.item.changeDate).toLocaleString()
    }
  },
  created(){
    TimeAgo.addLocale(en)
    this.timeAgo = new TimeAgo('en-US')
  },
  components:{
    "vue-markdown":VueMarkdown
  }
})


</script>