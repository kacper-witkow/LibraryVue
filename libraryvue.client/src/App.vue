<template>
  <div class="w-full h-20 bg-yellow-200">
    <TopMenu />
  </div>
  <div class="flex flex-row bg-gradient-to-tr from-slate-700 to-blue-400 justify-center h-screen">
      <MainPage />
  </div>
</template>


<script>
import TopMenu from './components/TopMenu.vue'
import MainPage from './components/MainPage.vue'

export default{

  components: {
    TopMenu,
    MainPage
  }
}
</script>