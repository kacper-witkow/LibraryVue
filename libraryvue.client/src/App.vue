<template>
  <div class="h-screen w-full bg-gradient-to-r from-indigo-500/75 via-purple-500 to-pink-500 bg-transparent">
    <h1 className="text-center  font-serif text-4xl">List todo</h1>

    <div class="content-center">
      <input type="text" placeholder="todo" v-model="newTodo" class="m-4 bg-yellow-200">

      <button className=" text-white m-2 p-3 rounded hover:bg-violet-600 actice: bg-blue-500"
        @click="AddToList">Naciśnij</button>
    </div>
    <div v-for="item in items" v-bind:key="item.id" class=" flex m-1">
      <h2 v-if="!item.completed" class="bg-red-400 w-32 m-1 text-center">
        {{ item.title }}
      </h2>
      <button
        class="w-28 m-1 bg-blue-500 text-cyan-50 text-2xl shadow-m rounded-md hover:bg-sky-600 focus:outline-none focus:ring focus:ring-violet-300"
        @click="zrobione(item.id)" v-if="!item.completed">
        zrobione
      </button>


      <div v-for="item in items" v-bind:key="item.id" class="flex">
        <h2 v-if="item.completed" class="bg-green-400">
          {{ item.title }}
        </h2>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  data() {
    return {
      newTodo: '',
      items: []
    }
  },
  methods: {
    AddToList() {
      if (this.newTodo != "") {
        this.items.push({
          title: this.newTodo,
          completed: false,
          id: this.items.length
        })
        this.newTodo = ''
      }
    },
    zrobione(id) {
      this.items[id].completed = true;
    }
  }
}
</script>