<template>
    <div class="button-set">
      <div class="wb-fix-button-br green" v-if="showAddBtn && !isShowGoUpButton" @click.prevent.stop="onAddWordOpen()">
        <i class="fa fa-plus"></i>
      </div>
      
      <div class="wb-fix-button-br gray" v-show="isShowGoUpButton" @click.prevent.stop="goUp()">
        <i class="fas fa-arrow-up"></i>
      </div>
    </div>
</template>
<style lang="scss">
  @import "@/assets/_colors.scss";
.button-set {
    justify-content: flex-end;
    display: flex;
    padding: 8px;
}

.wb-fix-button-br {
    border-radius: 32px;
    padding: 18px;
    position: fixed;
    bottom: 8px;
    box-shadow: 0 2px 2px rgba(190, 190, 190, .33);
    cursor: pointer;
    z-index:10;
}

.wb-fix-button-br i {
    color: $fix-button-color;
    font-size: 18px;
}

.wb-fix-button-br.green {
    border: 1px solid $primary-border-color;
    background-color: $primary-color;
}

.wb-fix-button-br.gray {
    border: 1px solid $gray-border-color;
    background-color: $gray-color;
}
</style>
<script lang="ts">
  import Vue from 'vue'
  export default Vue.extend({
    props: { "showAddBtn": Boolean, "scrollSaveName": String },

    data(){
      return {
        isShowGoUpButton: false,
        scrollRestored: false
      }
    },

    methods:{
      onAddWordOpen(){
        this.$emit("add")
      },
      
      goUp() {
        window.scroll(0, 0);
      },

      handleScroll(event: any) {
        this.isShowGoUpButton = window.scrollY > 100
        if (this.scrollSaveName)
          localStorage.setItem(this.scrollSaveName, window.scrollY.toString())
      },

      listCreate() {
        window.addEventListener('scroll', this.handleScroll)
      },

      listDestroy() {
        window.removeEventListener('scroll', this.handleScroll)
      },

      recoverScroll(){
        if (!this.scrollSaveName) return;
        if (this.scrollRestored) return;
        if ("scrollRestoration" in history) {
          history.scrollRestoration = "manual"
        }

        let scroll_y = localStorage.getItem(this.scrollSaveName)
        if (scroll_y) window.scroll(0, parseInt(scroll_y))
          this.scrollRestored = true
      }
    },

    created(){
      this.listCreate()
      this.recoverScroll()
    },

    beforeDestroy(){
      this.listDestroy()
    },

    //#region updated

  updated() {
    this.$nextTick(function() {
       this.recoverScroll()
    });
  },
  //#endregion

  })
</script>