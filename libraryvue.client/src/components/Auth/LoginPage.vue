<template>
  <form class="mt-5 w-2/3 space-y-6 pl-20" @submit="onSubmit">
    <FormField name="username">
      <FormItem>
        <FormLabel>Username</FormLabel>
        <FormControl>
          <Input type="text" placeholder="Username" v-bind="componentField" />
        </FormControl>
        <FormDescription> This is your public display name. </FormDescription>
        <FormMessage />
      </FormItem>
    </FormField>

    <FormField name="email">
      <FormItem>
        <FormLabel>Email</FormLabel>
        <FormControl>
          <Input type="email" placeholder="Email" v-bind="componentField" />
        </FormControl>
        <FormMessage />
      </FormItem>
    </FormField>

    <FormField name="password">
      <FormItem>
        <FormLabel>Password</FormLabel>
        <FormControl>
          <Input
            type="password"
            placeholder="Password"
            v-bind="componentField"
          />
        </FormControl>
        <FormMessage />
      </FormItem>
    </FormField>
    <Button type="submit"> Submit </Button>
  </form>
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

export default {
  components: {
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
    Button,
    Input,
  },
  methods: {
    onSubmit(values) {
      console.log(values);
    },
  },
};
</script>
