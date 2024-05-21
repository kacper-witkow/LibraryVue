<template>
  <div class="mt-3">
    <div class="flex w-full flex-col object-center">
      <h1 class="text-center text-3xl">Welcome in our library</h1>
      <h1 v-if(isLogin) class="mt-3 text-center text-3xl">
        Below you can choose book you want to borrow
      </h1>
      <p v-if="book == null" class="mt-20 text-center text-5xl">
        Sorry no more books to borrow
      </p>
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
  </div>
</template>

<script setup>
import { watch, computed, ref, onMounted } from "vue";
import BookCard from "./Book/BookCard/BookCard.vue";
import useAuthStore from "@/store/module.js";
const store = useAuthStore();
const books = ref(null);

const isLogin = ref(computed(() => !!user?.token));

onMounted(async () => {
  console.log(store.token);
  const response = await fetch("/books/GetAllAvailableBooks", {
    method: "GET",
    credentials: "same-origin",
    headers: { Authorization: "Bearer " + store.token },
  });
  books.value = await response.json();
});
</script>
