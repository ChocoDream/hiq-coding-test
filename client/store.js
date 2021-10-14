import Vuex from 'vuex';

const store = new Vuex.Store({
  state: {
    text: "loremLipsum",
  },
  mutations: {
    setText(state, payload)
  },
  actions: {
    uploadFile({commit, state})
  }
})