<template>
  <div class="mt-4 text-center text-3xl" v-if="book">
    <h2>{{ book.title }}</h2>
    <h1>{{ book.author }}</h1>
    <button @click="downloadBook" class="m-5 rounded-md bg-blue-400 p-3">
      Download book
    </button>
  </div>
</template>
<script setup>
import axios from "axios";
import { watch, ref, onMounted } from "vue";
const props = defineProps(["id"]);
import useAuthStore from "@/store/module.js";
const store = useAuthStore();

const book = ref(null);

onMounted(async () => {
  const response = await fetch("/books/Get/" + props.id, {
    method: "GET",
    headers: { Authorization: "Bearer " + store.token },
  });
  console.log("Montowanie ");
  book.value = await response.json();
});

async function downloadBook() {
  axios
    .get(
      "/books/GetFile/" + props.id,

      {
        headers: { Authorization: "Bearer " + store.token },
        responseType: "blob", // Important to specify response type as blob
      },
    )
    .then((response) => {
      const blob = new Blob([response.data], {
        type: "application/pdf",
      });
      const link = document.createElement("a");
      link.href = URL.createObjectURL(blob);
      link.download = book.value["title"];
      link.click();
      URL.revokeObjectURL(link.href);
    })
    .catch(console.error);
}
</script>
