<template>
  <navbar class="flex w-screen justify-between bg-slate-400">
    <div class="flex">
      <routerLink class="m-4 text-2xl" :to="{ name: 'home' }"
        >Library</routerLink
      >
    </div>
    <div class="flex">
      <div v-if="!isLoggedIn" class="m-4 text-xl">
        <router-link :to="{ name: 'login' }">Log In</router-link>
      </div>
      <div v-else class="m-4 text-xl">
        <router-link :to="{ name: 'home' }" @click="SingOut"
          >Log Out</router-link
        >
      </div>
    </div>
  </navbar>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  computed: {
    ...mapGetters(["isLoggedIn", "getUsername"]),
  },
  methods: {
    SingOut() {
      this.$store.commit("SingOut");
    },
  },
};
</script>
