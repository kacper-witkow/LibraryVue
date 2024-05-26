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
        <FormLabel>Password</FormLabel>
        <FormItem>
          <FormControl>
            <Input type="password" placeholder="Password" v-model="Password" />
          </FormControl>
          <FormMessage />
        </FormItem>
      </FormField>
      <Button type="submit"> Log In </Button>
    </form>
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

async function Login() {
  console.log("Logowanie admina");
  const response = await fetch("/auth/AdminLogin", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Email: Email.value,
      Password: Password.value,
    }),
  });
  const { username, token, expiration } = await response.json();
  console.log(username, token);
  storeAuth.setUser(username);
  storeAuth.setToken(token);
  storeAuth.setAdmin();
  await router.push({ name: "home" });
}

const Password = ref("");
const Email = ref("");
const title = "Admin log in";
const backHrefLink = "./";
const backHrefText = "";
</script>
