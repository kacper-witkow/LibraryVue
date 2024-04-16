<template>
  <TopMenu />
  <div class="flex justify-center">
    <p v-if="isLoggedIn">Hello</p>
    <router-view />
  </div>
</template>

<script>
import TopMenu from "./components/TopMenu.vue";
import { mapGetters } from "vuex";
export default {
  components: {
    TopMenu,
  },
  computed: {
    ...mapGetters(["isLoggedIn"]),
  },
};
</script>
