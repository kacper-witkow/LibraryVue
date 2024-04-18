<template>
  <div class="flex">
    <div class="w-1/12"></div>
    <div
      class="m-2 flex h-auto w-5/6 justify-between rounded-sm border-2 bg-sky-200 p-3 text-lg"
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
    <div class="w-1/12"></div>
  </div>
</template>

<script>
export default {
  props: {
    title: String,
    author: String,
    numberOfPages: Number,
    isBorrowed: Boolean,
  },
};
</script>
