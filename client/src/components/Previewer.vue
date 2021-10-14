<template>
  <div>
    Preview
    <p>{{processedText}}</p>
  </div>
</template>

<script>
  export default { 
    computed:{
      processedText() {
        return this.$store.state.text
      }
    }
  }
</script>

<style scoped>

</style>