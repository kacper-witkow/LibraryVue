import LoginPage from "../view/Auth/LoginPage.vue";
import RegisterPage from "../view/Auth/RegisterPage.vue";
import MainPage from "../view/MainPage.vue";
import NotFound from "../view/NotFound.vue";
import BookDetailsPage from "../view/Book/BookDetailsPage.vue";
import { createRouter, createWebHistory } from "vue-router";

export default createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", name: "home", component: MainPage },
    { path: "/login", name: "login", component: LoginPage },
    { path: "/register", name: "register", component: RegisterPage },
    {
      path: "/book/:id",
      name: "book",
      component: BookDetailsPage,
      props: true,
    },
    {
      path: "/:catchAll(.*)",
      name: "NotFound",
      component: NotFound,
    },
  ],
});
