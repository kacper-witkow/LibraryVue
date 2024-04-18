<template>
  <navbar class="flex w-screen justify-between bg-slate-400">
    <div class="flex">
      <routerLink class="m-4 text-2xl" :to="{ name: 'home' }"
        >Library</routerLink
      >
    </div>
    <div class="flex">
      <router-link class="m-4 text-xl" :to="{ name: 'login' }"
        >Log In</router-link
      >
    </div>
  </navbar>
</template>

<script></script>
