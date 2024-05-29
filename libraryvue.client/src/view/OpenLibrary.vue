<template>
  <div class="mt-3 w-5/6">
    <AddBookForm @CloseAddingBook="CloseAddingBook" v-if="AddingForm">
    </AddBookForm>
    <div class="flex w-full flex-col object-center">
      <h1 class="text-center text-3xl">Welcome in our library</h1>
      <div v-if="store.isLogin">
        <div v-if="store.isAdmin" class="content-center">
          <button
            class="w-full bg-green-200 text-2xl text-blue-600"
            @click="AddingForm = true"
          >
            Add new Book
          </button>
        </div>
        <h1 class="mt-3 text-center text-3xl">
          Below you can choose book you want to borrow
        </h1>
        <p
          v-if="books == null || books[0] == null"
          class="mt-20 text-center text-5xl"
        >
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
      <div v-else>
        <h1>Please log in to see our collection</h1>
      </div>
    </div>
  </div>
</template>

<script setup>
import { watch, computed, ref, onMounted } from "vue";
import BookCard from "./Book/BookCard/BookCard.vue";
import AddBookForm from "./Book/AddBookForm.vue";
import useAuthStore from "@/store/module.js";
const store = useAuthStore();
const books = ref(null);
const AddingForm = ref(false);

function CloseAddingBook() {
  AddingForm.value = false;
  GetAllAvailableBooks();
}
onMounted(async () => GetAllAvailableBooks());

async function GetAllAvailableBooks() {
  console.log(store.token);
  const response = await fetch("/books/GetAllAvailableBooks", {
    method: "GET",
    credentials: "same-origin",
    headers: { Authorization: "Bearer " + store.token },
  });
  books.value = await response.json();
}
</script>
