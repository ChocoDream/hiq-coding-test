<template>
  <div class="uploader-container">
    <h3>Upload File by clicking "Upload" or drag file to box</h3>
    <div class="upload-wrapper">
      <input
        type="file"
        id="fileInput"
        ref="fileInput"
        @change="onFileUpload"
        accept=".txt,.rtf,.md"
      />
    </div>
    <h3>{{ status }}</h3>
  </div>
</template>

<script>
export default {
  components: {},
  computed: {
    status() {
      return this.$store.state.fileStatus;
    },
  },
  methods: {
    onFileUpload(event) {
      const files = event.target.files;
      const formData = new FormData();
      formData.append("file", files[0]);
      this.$store.dispatch("uploadFile", { value: formData });
    },
  },
};
</script>

<style scoped>
.drop-box {
  display: flex;
  justify-content: center;
  width: 100px;
  background: red;
}
</style>
