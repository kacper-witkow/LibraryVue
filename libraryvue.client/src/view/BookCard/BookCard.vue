<template>
  <div class="flex w-full">
    <router-link class="w-full" :to="{ name: 'book', params: { id: this.id } }">
      <div
        class="m-2 flex h-auto justify-between rounded-sm border-2 bg-sky-200 p-3 text-lg"
      >
        <div class="flex">
          <p class="flex p-1">{{ title }}</p>

          <p class="flex p-1">~{{ author }}</p>
        </div>
        <div class="flex">
          <p>Number of pages -{{ numberOfPages }}</p>
          <button
            class="ml-3 rounded-md bg-red-400 p-1 shadow-md hover:bg-red-600"
          >
            delete
          </button>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
export default {
  props: {
    title: String,
    author: String,
    numberOfPages: Number,
    isBorrowed: Boolean,
    id: Number,
  },
};
</script>
