<!-- eslint-disable vue/no-reserved-component-names -->
<template>
  <CardWrapper
    :title="title"
    :backHrefText="backHrefText"
    :backHrefLink="backHrefLink"
  >
    <form class="mb-5 mt-5 space-y-6" @submit.prevent="Register">
      <FormField name="Username">
        <FormItem>
          <FormLabel>Username</FormLabel>
          <FormControl>
            <Input type="text" placeholder="Username" v-model="Username" />
          </FormControl>
          <FormMessage />
        </FormItem>
      </FormField>
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
          <FormMessage />
        </FormItem>
      </FormField>
      <Button type="submit"> Register </Button>
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
import { useRouter } from "vue-router";

const router = useRouter();
async function Register() {
  console.log("Rejestrowanie");
  const response = await fetch("/auth/register-admin", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Username: Username.value,
      Email: Email.value,
      Password: Password.value,
    }),
  });
  console.log(response.json());
  router.push({ name: "home" });
}

const Email = ref("");
const Username = ref("");
const Password = ref("");
const title = "Register";
const backHrefText = "You already have account?";
const backHrefLink = "./login";
</script>
