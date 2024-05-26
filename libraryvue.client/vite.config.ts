import { fileURLToPath, URL } from "node:url";

import { defineConfig } from "vite";
import plugin from "@vitejs/plugin-vue";
import { env } from "process";
import tailwind from "tailwindcss";
import autoprefixer from "autoprefixer";

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
    ? env.ASPNETCORE_URLS.split(";")[0]
    : "https://localhost:8081";

// https://vitejs.dev/config/
export default defineConfig({
  css: {
    postcss: {
      plugins: [tailwind(), autoprefixer()],
    },
  },
  plugins: [plugin()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
  },
  server: {
    proxy: {
      "/books": {
        target: "https://localhost:8081/api/Book",
        changeOrigin: true,
        secure: false,
        ws: true,
        rewrite: (path) => path.replace(/^\/books/, ""),
      },
      "/auth": {
        target: "https://localhost:8081/Api/Authenticate",
        changeOrigin: true,
        secure: false,
        ws: true,
        rewrite: (path) => path.replace(/^\/auth/, ""),
      },
    },
    port: 5137,
  },
});
