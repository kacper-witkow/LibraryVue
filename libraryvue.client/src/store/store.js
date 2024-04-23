import { createStore } from "vuex";

// Create a new store instance.
const store = createStore({
  state: {
    user: null,
    token: null,
  },
  mutations: {
    setUser(state, user) {
      console.log("Set user to:" + user);
      state.user = user;
    },
    setToken(state, token) {
      console.log("Set token to:" + token);
      state.token = token;
    },
    SingOut(state) {
      state.token = null;
      state.user = null;
    },
  },
  actions: {},
  getters: {
    isLoggedIn(state) {
      return state.token;
    },
    getUsername(state) {
      return state.user;
    },
  },
});

export default store;
