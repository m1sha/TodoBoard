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
     selected: Object,
     type: String
  },
  model: {
     prop: "selected",
     event: "change-selected"
  },
  methods:{
    onSelect(uid: string | number){
      let res = uid
      if (this.type === "number")
        res = parseInt(uid as string)
      this.$emit("change-selected", res)
    }

  },

  mounted(){
    const { select } = this.$refs
    var j = {} as any
    var ctx = this
    eval(` 
    $(select).select2()
    $(select).on('select2:select', function (e) {
      var uid = e.params.data.id;
      ctx.onSelect(uid)
    });
    `)
    


  }
})
</script>