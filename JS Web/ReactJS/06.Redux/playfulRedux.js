import { createStore } from 'redux'


let separateStore = ()=>{
    console.log('---------UpdatedStore---------')
    console.log(store.getState())
}
let store = createStore(
  (store, action) => {
    if (action.type === 'ADD_ELEMENT') {
      return store.concat(action.payload)
    }
    return store
  },
  ['Use Redux']
)
separateStore()
store.dispatch({
  type: 'ADD_ELEMENT',
  payload: ['New Prop']
})
separateStore()
