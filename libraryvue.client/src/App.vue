<template>
  <TopMenu />
  <div class="flex justify-center">
    <router-view />
  </div>
</template>

<script setup>
import TopMenu from "./view/TopMenu.vue";
import useAuthStore from "./store/module.js";
</script>
