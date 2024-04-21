<template>
  <div>
    <p>My name is {{ name }}</p>
    <p>My age is {{ age }}</p>
  </div>
</template>
<script>
export default {
  setup() {
    let name = "TEST";
    let age = 28;
    return { name, age };
  },
};
</script>
