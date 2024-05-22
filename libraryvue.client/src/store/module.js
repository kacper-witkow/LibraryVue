import { defineStore } from "pinia";

// Create a new store instance.
export const useAuthStore = defineStore("auth", {
  state: () => ({
    user: null,
    token: null,
    isAdmin: false,
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
    setAdmin() {
      console.log("Admin set");
      this.isAdmin = true;
    },
    SingOut() {
      this.token = "";
      this.user = "";
    },
  },
  getters: {
    isLogin: (state) => !!state.user,
  },
  persist: true,
});

export default useAuthStore;
