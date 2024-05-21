<template>
  <div class="m-3 flex w-full">
    <div
      class="flex h-auto justify-between rounded-sm border-2 bg-sky-200 p-3 text-lg"
    >
      <div class="flex">
        <p class="flex p-1">{{ title }}</p>

        <p class="flex p-1">~{{ author }}</p>
      </div>
      <div class="flex">
        <p>Number of pages -{{ numberOfPages }}</p>
        <button
          v-if="!isBorrowed"
          class="ml-3 rounded-md bg-green-400 p-1 shadow-md hover:bg-green-600"
          @click="BorrowBook"
        >
          borrow
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps([
  "id",
  "author",
  "title",
  "numberOfPages",
  "isBorrowed",
]);

import useAuthStore from "@/store/module.js";
const store = useAuthStore();

async function BorrowBook(id) {
  await fetch("/books/borrowBook/" + props.id, {
    method: "POST",
    credentials: "same-origin",
    headers: { Authorization: "Bearer " + store.token },
  });
}
</script>
