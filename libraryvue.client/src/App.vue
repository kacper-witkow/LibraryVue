<template>
  <div class="h-20 w-full bg-blue-300">
    <TopMenu />
  </div>
  <div
    class="h-screen w-full justify-center bg-gradient-to-tr from-slate-600 to-blue-400"
  >
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
