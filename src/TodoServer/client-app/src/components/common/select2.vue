<template>

<select ref="select" v-model="selected">
  <option v-for="(item, index) in items" :value="item.id" :key="index" >
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
    onSelect(id: string | number){
      let res = id
      if (this.type === "number")
        res = parseInt(id as string)
      this.$emit("change-selected", res)
    }

  },

  mounted(){
    const { select } = this.$refs
    var j = {} as any
    var ctx = this
    eval(` 
    $(select).select2({ containerCssClass: "select" })
    $(select).on('select2:select', function (e) {
      var id = e.params.data.id;
      ctx.onSelect(id)
    });
    `)
    


  }
})
</script>