<template>
  <div>
    <h1>
      {{ this.book.title }}
    </h1>
    <h2>
      {{ this.book. }}
    </h2>
  </div>
</template>
<script>
export default {
  method: {
    data() {
      return { book: null };
    },
    GetBook() {
      fetch("/books/Get/" + $route.params.id, {
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
};
</script>
