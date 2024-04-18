<template>
  <br />
  <div class="flex flex-col object-center">
    <div v-for="book in books" :key="book.id">
      <BookCard
        :title="book.title"
        :author="book.autor"
        :numberOfPages="book.numerOfPages"
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
    GetBook() {
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
    this.GetBook();
  },
};
</script>
