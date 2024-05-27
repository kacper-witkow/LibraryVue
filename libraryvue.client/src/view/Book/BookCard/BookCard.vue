<template>
  <div class="m-3 flex w-full justify-center">
    <div
      class="flex h-auto w-full justify-between rounded-sm border-2 bg-sky-200 p-3 text-lg"
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
        <RouterLink
          :to="{ path: '/book/' + props.id, params: props.id }"
          class="ml-3 rounded-md bg-blue-400 p-1 shadow-md hover:bg-blue-600"
        >
          info
        </RouterLink>
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
import { useRouter } from "vue-router";
const store = useAuthStore();
const router = useRouter();

async function BorrowBook(id) {
  await fetch("/books/borrowBook/" + props.id, {
    method: "POST",
    credentials: "same-origin",
    headers: { Authorization: "Bearer " + store.token },
  });
  router.push("/");
}
</script>
