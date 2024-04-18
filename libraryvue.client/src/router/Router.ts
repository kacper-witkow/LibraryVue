import LoginPage from "../view/Auth/LoginPage.vue";
import RegisterPage from "../view/Auth/RegisterPage.vue";
import MainPage from "../view/MainPage.vue";
import { createRouter, createWebHistory } from "vue-router";

export default createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", component: MainPage },
    { path: "/login", component: LoginPage },
    { path: "/register", component: RegisterPage },
  ],
});
