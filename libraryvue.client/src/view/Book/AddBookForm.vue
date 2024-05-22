<template>
  <Form
    class="absolute h-full w-5/6 bg-slate-600 p-3 text-white"
    @submit.prevent="AddBook"
  >
    <FormField name="BookAddingForm">
      <FormLabel>Add new book</FormLabel>
      <FormItem>
        <FormLabel>Title</FormLabel>
        <FormControl>
          <Input type="text" placeholder="title" v-model="title" />
        </FormControl>
      </FormItem>

      <FormItem>
        <FormLabel>Author</FormLabel>
        <FormControl>
          <Input type="text" placeholder="Author" v-model="Author" />
        </FormControl>
      </FormItem>

      <FormItem>
        <FormLabel> Number of pages</FormLabel>
        <FormControl>
          <Input type="number" v-model="numberOfPages" />
        </FormControl>
      </FormItem>

      <FormItem>
        <FormLabel>Source</FormLabel>
        <FormControl>
          <Input type="file" v-model="file" />
        </FormControl>
      </FormItem>
    </FormField>
    <Button class="m-2" type="submit"> Add Book</Button>
  </Form>
</template>
<script setup>
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";

async function AddBook() {
  console.log("Adding book");
  const response = await fetch("/books/CreateBook", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Author: Author.value,
      Title: Title.value,
      NumberOfPages: NumberOfPages.value,
    }),
  });
  console.log("Book: " + Title.value + " Added");
}
</script>
