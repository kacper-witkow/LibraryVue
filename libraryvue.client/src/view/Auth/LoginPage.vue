<template>
  <CardWrapper
    :title="title"
    :backHrefText="backHrefText"
    :backHrefLink="backHrefLink"
  >
    <form class="mb-5 mt-5 space-y-6" @submit.prevent="Login">
      <FormField name="email">
        <FormItem>
          <FormLabel>Email</FormLabel>
          <FormControl>
            <Input type="email" placeholder="Email" v-model="Email" />
          </FormControl>
          <FormMessage />
        </FormItem>
      </FormField>
      <FormField name="password">
        <FormItem>
          <FormLabel>Password</FormLabel>
          <FormControl>
            <Input type="password" placeholder="Password" v-model="Password" />
          </FormControl>
        </FormItem>
      </FormField>
      <Button type="submit"> Log In </Button>
    </form>
    <p class="text-red-600">{{ errorLogin }}</p>
  </CardWrapper>
</template>

<script setup>
import { Button } from "@/components/ui/button";
import {
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import CardWrapper from "./CardWrapper.vue";
import { ref } from "vue";
import { useAuthStore } from "@/store/module.js";
import { useRouter } from "vue-router";
const storeAuth = useAuthStore();
const router = useRouter();
const errorLogin = ref(null);
async function Login() {
  console.log("Logowanie");
  const response = await fetch("/auth/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Email: Email.value,
      Password: Password.value,
    }),
  });
  if (response.status === 400 || response.status === 401)
    errorLogin.value = "Wrong email or password ";
  else {
    console.log(response.status);
    const { username, token, expiration } = await response.json();
    console.log(username, token);
    storeAuth.setUser(username);
    storeAuth.setToken(token);
    await router.push({ name: "home" });
  }
}

const Password = ref("");
const Email = ref("");
const title = "Log in";
const backHrefLink = "./register";
const backHrefText = "You don't have account?";

// export default {
//   components: {
//     FormControl,
//     FormDescription,
//     FormField,
//     FormItem,
//     FormLabel,
//     FormMessage,
//     CardWrapper,
//     Input,
//     Button,
//   },
//   methods: {
//     async Login() {
//       console.log("Logowanie");
//       const response = await fetch("/auth/login", {
//         method: "POST",
//         headers: {
//           "Content-Type": "application/json",
//         },
//         body: JSON.stringify({
//           Email: this.Email,
//           Password: this.Password,
//         }),
//       });
//       const { username, token, expiration } = await response.json();
//       this.$store.commit("setUser", username);
//       this.$store.commit("setToken", token);
//       this.$router.push({ name: "home" });
//     },
//   },
//   data() {
//     return {
//       Password: "",
//       Email: "",
//       title: "Log in",
//       backHrefLink: "./register",
//       backHrefText: "You don't have account?",
//     };
//   },
// };
</script>
