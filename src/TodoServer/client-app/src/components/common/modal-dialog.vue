
<template>
  <transition name="custom-modal">
    <div class="custom-modal-mask">
      <div class="custom-modal-wrapper" ref="wrapper">
        <div class="custom-modal-container" ref="container" @click="menuclick">
          <div class="custom-modal-header">
            <slot name="head"></slot>
          </div>

          <div class="custom-modal-body">
            <slot name="body"></slot>
          </div>

          <div class="custom-modal-footer">
            <slot name="footer"></slot>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>
<style lang="scss">
@import "@/assets/_dialog.scss";
</style>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  props: {
    showModal: Boolean,
    width: Number
  },

  data() {
    return {};
  },

  //#region created
  watch: {
    width: function() {
      const { container } = this.$refs;
      if (container && this.width) container.style.width = this.width;
    }
  },
  //#endregion

  mounted() {
    const { container, wrapper } = this.$refs;
    if (this.width) container.style.width = this.width;

    if (window.outerWidth < 321) {
      wrapper.style["align-items"] = "flex-start";
      wrapper.style["padding-top"] = "20px";
    } else {
      wrapper.style["align-items"] = "center";
      wrapper.style["padding-top"] = "0";
    }
  },

  methods: {
    menuclick(event) {
      event.stopPropagation();
    }
  },

  created() {
    const body = document.getElementsByTagName("body")[0];
    body.style.height = "100%";
    body.style.overflow = "hidden";
  },

  beforeDestroy: function() {
    const body = document.getElementsByTagName("body")[0];
    body.style.height = "auto";
    body.style.overflow = "auto";
  }
});
</script>

