<template>
  <div class="todo-card">
    <div class="todo-column" style="flex:1">
      <h3> {{item.title }}</h3>
      <code>{{item.message}}</code>
    </div>
    <div class="todo-column">
      <button class="btn btn-outline-secondary padding" @click="onEdit(item)">Edit</button>
      <button class="btn btn-outline-secondary padding" @click="onRemove(item)">Remove</button>
    </div>
    
  </div>
</template>
<style lang="scss">
@import "@/assets/_colors.scss";

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

h3{
  color: $text-color;
  font-size: 12pt;
}

code{
  color: $text-color-second;
}

.padding{
  margin: 2px;
}

</style>
<script lang="ts">
import Vue from 'vue'
import { TodoItem } from '@/entities/todo-item'
export default Vue.extend({
  props:{
    item : TodoItem
  },
  methods:{
    onEdit(item : TodoItem){
      this.$emit("edit", item)
    },
    onRemove(item : TodoItem){
      this.$emit("remove", item)
    }
  }
})
</script>