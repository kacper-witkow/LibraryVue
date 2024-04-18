<template>
  <TopMenu />
  <div class="flex justify-center">
    <p v-if="isLoggedIn">Hello</p>
    <router-view />
  </div>
</template>

<script>
import TopMenu from "./view/TopMenu.vue";
export default {
  components: {
    TopMenu,
  },
};
</script>
