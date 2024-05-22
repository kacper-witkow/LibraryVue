import LoginPage from "../view/Auth/LoginPage.vue";
import LoginPageAdmin from "../view/Auth/LoginPageAdmin.vue";
import RegisterPage from "../view/Auth/RegisterPage.vue";
import MainPage from "../view/MainPage.vue";
import OpenLibrary from "../view/OpenLibrary.vue";
import NotFound from "../view/NotFound.vue";
import BookDetailsPage from "../view/Book/BookDetailsPage.vue";
import { createRouter, createWebHistory } from "vue-router";
import text from "../view/text.vue";

export default createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", name: "home", component: MainPage },
    { path: "/OpenLibrary", name: "OpenLibrary", component: OpenLibrary },
    { path: "/login", name: "login", component: LoginPage },
    { path: "/AdminLogin", name: "AdminLogin", component: LoginPageAdmin },
    { path: "/register", name: "register", component: RegisterPage },
    { path: "/text", name: "text", component: text },
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
