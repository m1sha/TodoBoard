<template>

<select ref="select">

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
  mounted(){
    const {select} = this.$refs

    var j = {} as any
    eval(" $(select).select2()")
    


  }
})
</script>