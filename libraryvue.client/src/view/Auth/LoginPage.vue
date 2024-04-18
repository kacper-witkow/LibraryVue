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
          <FormMessage />
        </FormItem>
      </FormField>
      <Button type="submit"> Log In </Button>
    </form>
  </CardWrapper>
</template>

<script lang="ts">
import { useForm } from "vee-validate";
import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

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

export default {
  components: {
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
    CardWrapper,
    Input,
    Button,
  },
  methods: {
    //   ...mapMutations(["setUser", "setToken"]),
    async Login() {
      console.log(this.Password);
      console.log("Logowanie");
      const response = await fetch("/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Email: this.Email,
          Password: this.Password,
        }),
      });
      const { user, token } = await response.json();
      // this.setUser(user);
      // this.setToken(token);
      this.$router.push("/");
    },
  },
  data() {
    return {
      Password: "",
      Email: "",
      title: "Log in",
      backHrefLink: "./register",
      backHrefText: "You don't have account?",
    };
  },
};
</script>

<script setup lang="ts"></script>
