// vite.config.ts
import { fileURLToPath, URL } from "node:url";
import { defineConfig } from "file:///C:/Users/Prowojo/Desktop/LibraryWebSite/LibraryVue/libraryvue.client/node_modules/vite/dist/node/index.js";
import plugin from "file:///C:/Users/Prowojo/Desktop/LibraryWebSite/LibraryVue/libraryvue.client/node_modules/@vitejs/plugin-vue/dist/index.mjs";
import { env } from "process";
import tailwind from "file:///C:/Users/Prowojo/Desktop/LibraryWebSite/LibraryVue/libraryvue.client/node_modules/tailwindcss/lib/index.js";
import autoprefixer from "file:///C:/Users/Prowojo/Desktop/LibraryWebSite/LibraryVue/libraryvue.client/node_modules/autoprefixer/lib/autoprefixer.js";
var __vite_injected_original_import_meta_url = "file:///C:/Users/Prowojo/Desktop/LibraryWebSite/LibraryVue/libraryvue.client/vite.config.ts";
var target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` : env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(";")[0] : "https://localhost:7021";
var vite_config_default = defineConfig({
  css: {
    postcss: {
      plugins: [tailwind(), autoprefixer()]
    }
  },
  plugins: [plugin()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", __vite_injected_original_import_meta_url))
    }
  },
  server: {
    proxy: {
      "/books": {
        target: "https://localhost:7021/api/Book",
        changeOrigin: true,
        secure: false,
        ws: true,
        rewrite: (path) => path.replace(/^\/books/, "")
      },
      "/auth": {
        target: "https://localhost:7021/Api/Authenticate",
        changeOrigin: true,
        secure: false,
        ws: true,
        rewrite: (path) => path.replace(/^\/auth/, "")
      }
    },
    port: 5173
  }
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcudHMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCJDOlxcXFxVc2Vyc1xcXFxQcm93b2pvXFxcXERlc2t0b3BcXFxcTGlicmFyeVdlYlNpdGVcXFxcTGlicmFyeVZ1ZVxcXFxsaWJyYXJ5dnVlLmNsaWVudFwiO2NvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9maWxlbmFtZSA9IFwiQzpcXFxcVXNlcnNcXFxcUHJvd29qb1xcXFxEZXNrdG9wXFxcXExpYnJhcnlXZWJTaXRlXFxcXExpYnJhcnlWdWVcXFxcbGlicmFyeXZ1ZS5jbGllbnRcXFxcdml0ZS5jb25maWcudHNcIjtjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfaW1wb3J0X21ldGFfdXJsID0gXCJmaWxlOi8vL0M6L1VzZXJzL1Byb3dvam8vRGVza3RvcC9MaWJyYXJ5V2ViU2l0ZS9MaWJyYXJ5VnVlL2xpYnJhcnl2dWUuY2xpZW50L3ZpdGUuY29uZmlnLnRzXCI7aW1wb3J0IHsgZmlsZVVSTFRvUGF0aCwgVVJMIH0gZnJvbSBcIm5vZGU6dXJsXCI7XHJcblxyXG5pbXBvcnQgeyBkZWZpbmVDb25maWcgfSBmcm9tIFwidml0ZVwiO1xyXG5pbXBvcnQgcGx1Z2luIGZyb20gXCJAdml0ZWpzL3BsdWdpbi12dWVcIjtcclxuaW1wb3J0IHsgZW52IH0gZnJvbSBcInByb2Nlc3NcIjtcclxuaW1wb3J0IHRhaWx3aW5kIGZyb20gXCJ0YWlsd2luZGNzc1wiO1xyXG5pbXBvcnQgYXV0b3ByZWZpeGVyIGZyb20gXCJhdXRvcHJlZml4ZXJcIjtcclxuXHJcbmNvbnN0IHRhcmdldCA9IGVudi5BU1BORVRDT1JFX0hUVFBTX1BPUlRcclxuICA/IGBodHRwczovL2xvY2FsaG9zdDoke2Vudi5BU1BORVRDT1JFX0hUVFBTX1BPUlR9YFxyXG4gIDogZW52LkFTUE5FVENPUkVfVVJMU1xyXG4gICAgPyBlbnYuQVNQTkVUQ09SRV9VUkxTLnNwbGl0KFwiO1wiKVswXVxyXG4gICAgOiBcImh0dHBzOi8vbG9jYWxob3N0OjcwMjFcIjtcclxuXHJcbi8vIGh0dHBzOi8vdml0ZWpzLmRldi9jb25maWcvXHJcbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XHJcbiAgY3NzOiB7XHJcbiAgICBwb3N0Y3NzOiB7XHJcbiAgICAgIHBsdWdpbnM6IFt0YWlsd2luZCgpLCBhdXRvcHJlZml4ZXIoKV0sXHJcbiAgICB9LFxyXG4gIH0sXHJcbiAgcGx1Z2luczogW3BsdWdpbigpXSxcclxuICByZXNvbHZlOiB7XHJcbiAgICBhbGlhczoge1xyXG4gICAgICBcIkBcIjogZmlsZVVSTFRvUGF0aChuZXcgVVJMKFwiLi9zcmNcIiwgaW1wb3J0Lm1ldGEudXJsKSksXHJcbiAgICB9LFxyXG4gIH0sXHJcbiAgc2VydmVyOiB7XHJcbiAgICBwcm94eToge1xyXG4gICAgICBcIi9ib29rc1wiOiB7XHJcbiAgICAgICAgdGFyZ2V0OiBcImh0dHBzOi8vbG9jYWxob3N0OjcwMjEvYXBpL0Jvb2tcIixcclxuICAgICAgICBjaGFuZ2VPcmlnaW46IHRydWUsXHJcbiAgICAgICAgc2VjdXJlOiBmYWxzZSxcclxuICAgICAgICB3czogdHJ1ZSxcclxuICAgICAgICByZXdyaXRlOiAocGF0aCkgPT4gcGF0aC5yZXBsYWNlKC9eXFwvYm9va3MvLCBcIlwiKSxcclxuICAgICAgfSxcclxuICAgICAgXCIvYXV0aFwiOiB7XHJcbiAgICAgICAgdGFyZ2V0OiBcImh0dHBzOi8vbG9jYWxob3N0OjcwMjEvQXBpL0F1dGhlbnRpY2F0ZVwiLFxyXG4gICAgICAgIGNoYW5nZU9yaWdpbjogdHJ1ZSxcclxuICAgICAgICBzZWN1cmU6IGZhbHNlLFxyXG4gICAgICAgIHdzOiB0cnVlLFxyXG4gICAgICAgIHJld3JpdGU6IChwYXRoKSA9PiBwYXRoLnJlcGxhY2UoL15cXC9hdXRoLywgXCJcIiksXHJcbiAgICAgIH0sXHJcbiAgICB9LFxyXG4gICAgcG9ydDogNTE3MyxcclxuICB9LFxyXG59KTtcclxuIl0sCiAgIm1hcHBpbmdzIjogIjtBQUE0WSxTQUFTLGVBQWUsV0FBVztBQUUvYSxTQUFTLG9CQUFvQjtBQUM3QixPQUFPLFlBQVk7QUFDbkIsU0FBUyxXQUFXO0FBQ3BCLE9BQU8sY0FBYztBQUNyQixPQUFPLGtCQUFrQjtBQU5vTyxJQUFNLDJDQUEyQztBQVE5UyxJQUFNLFNBQVMsSUFBSSx3QkFDZixxQkFBcUIsSUFBSSxxQkFBcUIsS0FDOUMsSUFBSSxrQkFDRixJQUFJLGdCQUFnQixNQUFNLEdBQUcsRUFBRSxDQUFDLElBQ2hDO0FBR04sSUFBTyxzQkFBUSxhQUFhO0FBQUEsRUFDMUIsS0FBSztBQUFBLElBQ0gsU0FBUztBQUFBLE1BQ1AsU0FBUyxDQUFDLFNBQVMsR0FBRyxhQUFhLENBQUM7QUFBQSxJQUN0QztBQUFBLEVBQ0Y7QUFBQSxFQUNBLFNBQVMsQ0FBQyxPQUFPLENBQUM7QUFBQSxFQUNsQixTQUFTO0FBQUEsSUFDUCxPQUFPO0FBQUEsTUFDTCxLQUFLLGNBQWMsSUFBSSxJQUFJLFNBQVMsd0NBQWUsQ0FBQztBQUFBLElBQ3REO0FBQUEsRUFDRjtBQUFBLEVBQ0EsUUFBUTtBQUFBLElBQ04sT0FBTztBQUFBLE1BQ0wsVUFBVTtBQUFBLFFBQ1IsUUFBUTtBQUFBLFFBQ1IsY0FBYztBQUFBLFFBQ2QsUUFBUTtBQUFBLFFBQ1IsSUFBSTtBQUFBLFFBQ0osU0FBUyxDQUFDLFNBQVMsS0FBSyxRQUFRLFlBQVksRUFBRTtBQUFBLE1BQ2hEO0FBQUEsTUFDQSxTQUFTO0FBQUEsUUFDUCxRQUFRO0FBQUEsUUFDUixjQUFjO0FBQUEsUUFDZCxRQUFRO0FBQUEsUUFDUixJQUFJO0FBQUEsUUFDSixTQUFTLENBQUMsU0FBUyxLQUFLLFFBQVEsV0FBVyxFQUFFO0FBQUEsTUFDL0M7QUFBQSxJQUNGO0FBQUEsSUFDQSxNQUFNO0FBQUEsRUFDUjtBQUNGLENBQUM7IiwKICAibmFtZXMiOiBbXQp9Cg==
