<template>
  <br />
  <button @click="GetBooks" class="bg-slate-50 p-10"></button>
  <div class="flex justify-center">
    <BookCard />
  </div>
</template>

<script>
import BookCard from "./BookCard/BookCard.vue";

export default {
  components: {
    BookCard,
  },
  methods: {
    GetBooks: async function () {
      const response = await fetch("https://localhost:7021/api/Book/GetAll");
      const names = await response.json();
      console.log(names);
    },
  },
};
</script>
