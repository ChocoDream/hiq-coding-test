import Vuex from "vuex";
import Vue from "vue";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    text: "blub blub",
  },
  mutations: {
    setText() {},
  },
  actions: {
    uploadFile() {},
  },
});

export default store;
