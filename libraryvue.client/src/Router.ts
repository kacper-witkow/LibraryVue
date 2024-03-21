import LoginPage from "./components/Auth/LoginPage.vue";
import RegisterPage from "./components/Auth/RegisterPage.vue";
import MainPage from "./components/MainPage.vue";
import { createRouter, createWebHistory } from "vue-router";

export default createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", component: MainPage },
    { path: "/login", component: LoginPage },
    { path: "/register", component: RegisterPage },
  ],
});
