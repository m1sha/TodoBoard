<template>

<select ref="select" v-model="selected">
  <option v-for="(item, index) in items" :value="item.uid" :key="index" >
     {{item.name}}
  </option>
</select>

</template>
<style>
.select2-container--open {
    z-index: 9999999
}
</style>

<script lang="ts">
import Vue from 'vue'



export default Vue.extend({
  props:{
     items: Array,
     selected: Object
  },
   model: {
     prop: "selected",
     event: "change-selected"
   },

  mounted(){
    const {select} = this.$refs

    var j = {} as any
    eval(" $(select).select2()")
    


  }
})
</script>