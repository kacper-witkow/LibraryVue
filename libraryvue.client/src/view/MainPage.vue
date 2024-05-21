<template>
  <div class="flex w-5/6 flex-col object-center">
    <h1 class="text-center text-3xl">Welcome in our library</h1>
    <h1 v-if(isLogin) class="text-center text-3xl">Hi {{ store.user }}</h1>
    <div v-for="book in books" :key="book['id']">
      <BookCard
        :title="book['title']"
        :author="book['author']"
        :numberOfPages="book['numberOfPages']"
        :isBorrowed="book['isBorrowed']"
        :id="book['id']"
      />
    </div>
  </div>
</template>

<script setup>
import { watch, ref } from "vue";
import BookCard from "./BookCard/BookCard.vue";
import useAuthStore from "@/store/module.js";
const store = useAuthStore();
const books = ref(null);

watch(
  books,
  async () => {
    const response = await fetch("/books/Getall", {
      method: "GET",
    });
    books.value = await response.json();
  },
  { immediate: true },
);
</script>
