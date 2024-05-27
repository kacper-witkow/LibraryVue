<template>
  <div class="mt-4 text-center text-3xl" v-if="book">
    <h2>{{ book.title }}</h2>
    <h1>{{ book.author }}</h1>
    <button on-click="DownloadFile" class="m-5 rounded-md bg-blue-400 p-3">
      Download book
    </button>
  </div>
</template>
<script setup>
import { watch, ref, onMounted } from "vue";
const props = defineProps(["id"]);

const book = ref(null);

onMounted(async () => {
  const response = await fetch("/books/Get/" + props.id, {
    method: "GET",
  });
  console.log("Montowanie ");
  book.value = await response.json();
});
</script>
