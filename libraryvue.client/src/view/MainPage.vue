<template>
  <div class="flex w-5/6 flex-col object-center">
    <h1 class="text-center text-3xl">Welcome in our library</h1>
    <div v-if="store.isLogin">
      <h1 class="text-center text-3xl">Hi {{ store.user }}</h1>
      <div v-for="book in books" :key="book['id']">
        <BookCard
          :title="book['title']"
          :author="book['author']"
          :numberOfPages="book['numberOfPages']"
          :UserName="book['userName']"
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

onMounted(async () => {
  console.log(store.token);
  const response = await fetch("/books/GetAllAuth", {
    method: "GET",
    credentials: "same-origin",
    headers: { Authorization: "Bearer " + store.token },
  });
  books.value = await response.json();
});
</script>
