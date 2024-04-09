<template>
  <TopMenu />
  <router-view />
</template>

<script>
import TopMenu from "./components/TopMenu.vue";

export default {
  components: {
    TopMenu,
  },
};
</script>
