<template>
  <TopMenu />
  <div class="flex justify-center">
    <router-view />
  </div>
</template>

<script>
import TopMenu from "./components/TopMenu.vue";

export default {
  components: {
    TopMenu,
  },
};
</script>
