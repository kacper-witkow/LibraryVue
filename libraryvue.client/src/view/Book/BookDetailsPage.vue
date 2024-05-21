<template>
  <div class="mt-4 text-center text-3xl">
    <h1>
      {{ book.title }}
    </h1>
    <h2>
      {{ book.author }}
    </h2>
  </div>
</template>
<script setup>
import { watch, ref, onMounted } from "vue";
const props = defineProps(["id", "author", "title"]);

const book = ref(null);

onMounted(async () => {
  const response = await fetch("/books/Get/" + props.id, {
    method: "GET",
  });
  book.value = await response.json();
});
</script>
