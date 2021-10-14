<template>
  <div id="app">
    <Navbar />
    <Previewer />
  </div>
</template>

<script>
import Navbar from "./components/Navbar.vue"
import Previewer from "./components/Previewer.vue"
export default {
  name: 'App',
  components: {
    Navbar,
    Previewer
  }
}
</script>

<style>
:root{
  --primary: #555;
  --secondary: #333;
  --text: #777;
}
*{
  margin: 0;
  padding: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
