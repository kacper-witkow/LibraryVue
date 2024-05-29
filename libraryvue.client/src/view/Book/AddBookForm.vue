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
          <Input type="text" placeholder="Author" v-model="author" />
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
    <div class="flex justify-between">
      <Button class="m-4" type="submit"> Add Book</Button>
      <Button class="m-4" @click="CloseAddingBook">Close</Button>
    </div>
    <p class="text-3xl text-red-500">{{ errorAdding }}</p>
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
import { useRouter } from "vue-router";
import useAuthStore from "@/store/module.js";
const store = useAuthStore();
const router = useRouter();

const emit = defineEmits(["CloseAddingBook"]);

function CloseAddingBook() {
  emit("CloseAddingBook");
}

const file = ref(null);
const author = ref(null);
const title = ref(null);
const numberOfPages = ref(null);
const errorAdding = ref(null);
const uploadFile = (event) => {
  file.value = event.target.files[0];
};

async function AddBook() {
  let data = new FormData();
  let config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: "Bearer " + store.token,
    },
  };
  data.append("file", file.value);
  data.append("author", author.value);
  data.append("title", title.value);
  data.append("numberOfPages", numberOfPages.value);
  console.log("Adding book");
  const response = await axios
    .post("/books/CreateBook", data, config)
    .then(() => {
      console.log("Book: " + title.value + " Added");
      emit("CloseAddingBook");
    })
    .catch(() => {
      errorAdding.value = "Book can't be send";
    });
}
</script>
