import Login from "./components/Auth/Login.vue";
import Register from "./components/Auth/Register.vue";
import MainPage from "./components/MainPage.vue";
import { createRouter, createWebHistory } from "vue-router";

export default createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", component: MainPage },
    { path: "/login", component: Login },
    { path: "/register", component: Register },
  ],
});
