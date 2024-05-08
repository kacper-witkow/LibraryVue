import { createApp, watch } from "vue";
import App from "./App.vue";
import Router from "./router/Router";
import { createPinia } from "pinia";
import "./index.css";
import piniaPluginPersistedstate from "pinia-plugin-persistedstate";

const pinia = createPinia();

pinia.use(piniaPluginPersistedstate);

createApp(App).use(Router).use(pinia).mount("#app");
