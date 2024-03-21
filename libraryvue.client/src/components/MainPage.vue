<template>
  <br />
  <p class="bg-slate-100 text-center text-2xl text-red-700">
    Kurwa ma się pokazac
  </p>
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
