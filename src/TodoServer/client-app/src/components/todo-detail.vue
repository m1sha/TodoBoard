<template>
  <div>
    <div>
      <h3>{{todo.title}}</h3>
    </div>
    <article class="markdown-body">
      <vue-markdown :source="todo.message"></vue-markdown>
    </article>
  </div>
</template>
<style lang="scss" scoped>
@import "@/assets/github-markdown.scss";
@import "@/assets/_colors.scss";
h3{
  color: $text-color;
  font-size: 12pt;
}
</style>
<script lang="ts">
import Vue from 'vue'
import { TodoItem } from '@/entities/todo-item'
import VueMarkdown from 'vue-markdown'
export default Vue.extend({
  props:{
     todo: TodoItem,
   },
   model: {
     prop: "todo",
     event: "change-todo"
   },
   components:{
     "vue-markdown": VueMarkdown
   }
})
</script>