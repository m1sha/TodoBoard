<template>
  <div>
    <i v-if="status===1" class="fa fa-plus todo-status new" title="New"></i>
    <i v-if="status===2" class="fa fa-clock todo-status in-work" title="In work"></i>
    <i v-if="status===3" class="fa fa-check todo-status finished" title="Finished"></i>
  </div>
</template>
<style lang="scss">
   .todo-status{
     padding: 0 8px;
     font-size: 11pt;
   }
   .finished{
     color: #66d381;
   }
   .in-work{
     color: #d6d871;
   }
   .new{
     color: #b8bec5;
   }
</style>
<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  props:{
     status: Number,
   },
   model: {
     prop: "status",
     event: "change-status"
   },
})
</script>