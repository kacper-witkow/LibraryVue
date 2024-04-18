<template>
  <div v-if="this.book">
    <h1>
      {{ this.book.title }}
    </h1>
    hej
    <h2>
      {{ this.book.author }}
    </h2>
  </div>
</template>
<script>
export default {
  data() {
    return {
      book: null,
      //we get Id as a prop
      //id: this.$route.params.id,
    };
  },
  props: ["id"],
  methods: {
    async GetBook() {
      console.log("Download book" + this.id);
      fetch("/books/Get/" + this.id, {
        method: "GET",
      })
        .then((response) =>
          response.json().then((data) => console.log((this.book = data))),
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
