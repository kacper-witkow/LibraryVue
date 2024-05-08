import { defineStore } from "pinia";

// Create a new store instance.
export const useAuthStore = defineStore("auth", {
  state: () => ({
    user: null,
    token: null,
  }),
  actions: {
    setUser(user) {
      console.log("Set user to:" + user);
      this.user = user;
    },
    setToken(token) {
      console.log("Set token to:" + token);
      this.token = token;
    },
    SingOut() {
      this.token = null;
      this.user = null;
    },
  },
  persist: true,
});
