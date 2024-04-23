import { computed } from "vue";
import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";

// Create a new store instance.
const store = createStore({
  plugins: [
    createPersistedState({
      storage: window.sessionStorage,
    }),
  ],
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
    getBooks(state, books) {
      return books;
    },
    GetBooks(state) {
      const books = fetch("/books/GetAllAuth", {
        method: "GET",
        headers: {
          Authorization: "Bearer " + state.token,
        },
      })
        .then((response) => response.json().then((data) => (this.books = data)))
        .catch((err) => {
          console.error(err);
        });
      return books;
    },
  },
  computed: {
    console: () => console,
  },
});

export default store;
