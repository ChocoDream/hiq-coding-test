import Vuex from "vuex";
import Vue from "vue";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    processedFile: {
      content: "lorem lipsum lipsum",
      mostCommonWord: "lipsum",
      occurences: 2,
    },
    file: null,
    fileStatus: "EMPTY",
  },
  mutations: {
    setFile(state, payload) {
      state.processedFile = payload.value;
    },
    setStatus(state, status) {
      state.fileStatus = status;
    },
  },
  actions: {
    async uploadFile({ commit }, payload) {
      commit("setStatus", "PENDING");
      const options = {
        method: "POST",
        body: payload.value,
      };
      await fetch("http://localhost:5000/upload-file", options)
        .then((response) => {
          if (response.ok) {
            commit("setStatus", "RECIEVING");
          } else {
            throw commit("setStatus", "REJECTED");
          }
        })
        .then((result) => {
          console.log(result.json());
        })
        .catch((error) => {
          console.warn(error);
          commit("setStatus", "ERROR");
        });
    },
  },
});

export default store;
