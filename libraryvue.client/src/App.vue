<template>
  <div class="h-20 w-full bg-yellow-200">
    <TopMenu />
  </div>
  <div
    class="h-screen w-full justify-center bg-gradient-to-tr from-slate-700 to-blue-400"
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
