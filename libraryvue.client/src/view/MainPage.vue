<template>
  <div class="flex w-5/6 flex-col object-center">
    <div v-for="book in books" :key="book.id">
      <BookCard
        :title="book.title"
        :author="book.author"
        :numberOfPages="book.numberOfPages"
        :isBorrowed="book.isBorrowed"
      />
    </div>
  </div>
</template>

<script lang="ts">
import BookCard from "./BookCard/BookCard.vue";

export default {
  components: {
    BookCard,
  },
  data() {
    return {
      books: [],
    };
  },
  methods: {
    GetBooks() {
      fetch("/books/Getall", {
        method: "GET",
      })
        .then((response) =>
          response.json().then((data) => console.log((this.books = data))),
        )
        .catch((err) => {
          console.error(err);
        });
    },
  },
  mounted() {
    this.GetBooks();
  },
};
</script>
