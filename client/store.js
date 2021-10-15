import Vuex from "vuex";
import Vue from "vue";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    processedFile: {},
    file: null,
    fileStatus: "EMPTY",
  },
  mutations: {
    setProcessedFile(state, payload) {
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
      await fetch("http://localhost:5000/text", options)
        .then((response) => {
          return response.json();
        })
        .then((result) => {
          commit("setProcessedFile", { value: result });
          commit("setStatus", "SUCCESS");
        })
        .catch((error) => {
          console.warn(error);
          commit("setStatus", "ERROR");
        });
    },
    async getFileFromServer({ commit }) {
      //let result;
      const options = {
        method: "GET",
      };
      await fetch("http://localhost:5000/text", options)
        .then((response) => {
          return response.json();
        })
        .then((data) => {
          console.log(data);
          commit("setProcessedFile", { value: data });
        });
    },
  },
});

export default store;
