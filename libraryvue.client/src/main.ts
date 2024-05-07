import { createApp } from "vue";
import App from "./App.vue";
import Router from "./router/Router";
import { createPinia } from "pinia";
import "./index.css";

createApp(App).use(Router).use(createPinia()).mount("#app");
