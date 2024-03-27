<template>
  <div class="flex content-center justify-center">
    <form>
      <h3 class="m-1 text-center text-3xl">Sign In</h3>
      <div class="flex">
        <div class="flex flex-col">
          <label class="m-1 p-3">Email</label>
          <label class="m-1 p-3">Password</label>
        </div>

        <div class="flex flex-col">
          <input
            class="m-1 p-3"
            v-model="Email"
            type="email"
            placeholder="email"
          />
          <input
            class="m-1 p-3"
            v-model="Password"
            type="password"
            placeholder="password"
          />
        </div>
      </div>
      <div class="flex justify-center">
        <button
          class="m-1 content-center rounded-lg bg-cyan-500 p-2 text-center text-3xl hover:bg-green-600"
          v-on:click="Login"
        >
          Sign in
        </button>
      </div>
    </form>
  </div>
</template>
<script lang="ts">
export default {
  data() {
    return {
      Password: "",
      Email: "",
    };
  },
  methods: {
    Login() {
      console.log("logowanie");
    },
  },
};
</script>
