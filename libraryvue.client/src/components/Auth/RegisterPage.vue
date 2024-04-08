<template>
  <div class="flex content-center justify-center">
    <form>
      <h3 class="m-1 text-center text-3xl">Register</h3>
      <div class="flex justify-center">
        <div class="flex flex-col">
          <div>
            <label>Name</label>
            <input
              class="m-4 p-3"
              v-model="Name"
              type="text"
              placeholder="User name"
            />
          </div>

          <div>
            <label>Email</label>
            <input
              class="m-4 p-3"
              v-model="Email"
              type="email"
              placeholder="email"
            />
          </div>
          <div>
            <label>Password</label>
            <input
              class="m-4 p-3"
              v-model="Password"
              type="password"
              placeholder="password"
            />
          </div>
        </div>
      </div>
      <div class="m-1 text-center text-lg text-red-800" v-if="PasswordError">
        {{ PasswordError }}
      </div>
      <div class="flex justify-center">
        <Button @click.prevent="Register"> Sign up </Button>
      </div>
    </form>
  </div>
</template>

<script>
import { Button } from "@/components/ui/button";

export default {
  components: {
    Button,
  },
  data() {
    return {
      Email: "",
      Name: "",
      Password: "",
      PasswordError: "",
    };
  },
  methods: {
    async Register() {
      if (!this.PasswordError) {
        console.log("Rejestrowanie");
        const response = await fetch(
          "https://localhost:7021/api/authenticate/Register",
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              Username: this.Name,
              Email: this.Email,
              Password: this.Password,
            }),
          },
        );
        console.log(response.json());
      }
    },
  },
};
</script>
