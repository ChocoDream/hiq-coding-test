<template>
  <div>
    <div v-if="processedData">
      <h3>
        Most common Word: {{ processedData.mostCommonWord }} Occurrences:
        {{ processedData.occurrences }}
      </h3>
      <p>
        {{ processedData.content }}
      </p>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    processedData() {
      return this.$store.state.processedFile;
    },
  },
};
</script>

<style scoped></style>
