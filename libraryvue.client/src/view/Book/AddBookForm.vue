<template>
  <Form
    class="absolute h-full w-5/6 bg-slate-600 p-3 text-black"
    @submit="AddBook"
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
          <Input type="file" @change="uploadFile" />
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
import axios, * as others from "axios";
import { ref } from "vue";

const file = ref(null);
const uploadFile = (event) => {
  file.value = event.target.files[0];
};

async function AddBook() {
  let data = new FormData();
  let config = {
    header: {
      "Content-Type": "multipart/form-data",
    },
  };
  data.append("file", file.value);
  console.log("Adding book");
  const response = await axios.post("/books/CreateBook", data, config);
  console.log("Book: " + Title.value + " Added");
}
</script>
