<template>
  <div class="flex w-5/6 flex-col object-center">
    <p v-if="isLoggedIn">hello {{ getUsername }}</p>
    <div v-for="book in books" :key="book.id">
      <BookCard
        :title="book.title"
        :author="book.author"
        :numberOfPages="book.numberOfPages"
        :isBorrowed="book.isBorrowed"
        :id="book.id"
      />
    </div>
  </div>
</template>

<script lang="ts">
import BookCard from "./BookCard/BookCard.vue";
import { mapGetters } from "vuex";

export default {
  components: {
    BookCard,
  },
  data() {
    return {
      books: [],
    };
  },
  methods: {},
  mounted() {
    this.books = this.$store.commit("GetBooks");
  },
  computed: {
    ...mapGetters(["isLoggedIn", "getUsername"]),
  },
};
</script>
