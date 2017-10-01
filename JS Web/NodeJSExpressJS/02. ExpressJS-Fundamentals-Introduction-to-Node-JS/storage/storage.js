let fs = require('fs')
let internalStorage = new Map()

function put (key, value) {
  if (typeof key !== 'string') {
    console.log(`Key has to be string!`)
    return
  }
  if (internalStorage.has(key)) {
    console.log(`Key already exists`)
    return
  }
  internalStorage.set(key, value)
}

function get (key) {
  if (typeof key !== 'string') {
    console.log(`Key has to be string!`)
    return
  }
  if (!internalStorage.has(key)) {
    console.log(`Key does not exist!`)
    return
  }
  return internalStorage.get(key)
}

function getAll () {
  return internalStorage
}

function update (key, newValue) {
  if (typeof key !== 'string') {
    console.log(`Key has to be string!`)
    return
  }
  if (!internalStorage.has(key)) {
    console.log(`Key does not exist!`)
    return
  }
  internalStorage.set(key, newValue)
}

function remove (key) {
  if (typeof key !== 'string') {
    console.log(`Key has to be string!`)
    return
  }
  if (!internalStorage.has(key)) {
    console.log(`Key does not exist!`)
    return
  }
  internalStorage.delete(key)
}

function clear () {
  internalStorage.clear()
}

function save () {
  let resultObj = Object.create(null)
  for (let [key, value] of internalStorage) {
    resultObj[key] = value
  }
  fs.writeFileSync('./storage.json', JSON.stringify(resultObj))
}

function load () {
  fs.readFile('./storage.json', 'utf-8', (err, data) => {
    if (err) {
      return
    }

    let jsonData = JSON.parse(data)
    for (let key of Object.keys(jsonData)) {
      console.log(key + ' ' + jsonData[key])
      internalStorage.set(key, jsonData[key])
    }
  })
}

module.exports = {
  put: put,
  get: get,
  getAll: getAll,
  update: update,
  remove: remove,
  clear: clear,
  save: save,
  load: load
}
