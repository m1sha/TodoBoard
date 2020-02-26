<template>
  <div>
    <i v-if="type===1" class="fa fa-carrot todo-type feature" title="Feature"></i>
    <i v-if="type===2" class="fa fa-bug todo-type bug" title="Bug"></i>
    <i v-if="type===3" class="fa fa-hammer todo-type refactoring" title="Refactoring"></i>
  </div>
</template>
<style lang="scss">
   .todo-type{
     padding: 0 8px;
     font-size: 12pt;
   }
   .feature{
     color: #72f192;
   }
   .bug{
     color: #f593e4;
   }
   .refactoring{
     color: #72a9f1;
   }
</style>
<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  props:{
     type: Number,
   },
   model: {
     prop: "type",
     event: "change-type"
   },
})
</script>