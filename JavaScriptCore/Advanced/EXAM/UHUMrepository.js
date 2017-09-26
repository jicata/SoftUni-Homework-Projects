/*jshint esversion: 6 */
class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();
        this.id = 0;
    }

    get count() {
        return this.data.size;
    }

    add(entity) {
        if(this.validateEntity(entity)){
            this.data.set(this.id, entity);
            return this.id++;
        }

    }

    get(entityId) {
        let entity = this.data.get(entityId);
        if (!entity) {
            throw new Error(`Entity with id: ${entityId} does not exist!`)
        }
        return entity;
    }

    update(id, newEntity) {
        let entity = this.data.get(id);
        if (!entity) {
            throw new Error(`Entity with id: ${id} does not exist!`)
        }
        if(this.validateEntity(newEntity)){
            this.data.set(id, newEntity);
        }
    }

    del(id) {
        let entity = this.data.get(id);
        if (!entity) {
            throw new Error(`Entity with id: ${id} does not exist!`)
        }
        this.data.delete(id);
    }

    toString() {
        let result = '';
        for (let [id, entity] of this.data) {
            result += `${id} : ${JSON.stringify(entity)}\n`;
        }
        result = result.substr(0, result.length - 1);
        return result;
    }

    validateEntity(entity) {
        for (let property in this.props) {
            let entityProp = entity[property];
            if (!entityProp) {
                throw new Error(`Property ${property} is missing from the entity!`)
            }
            if (typeof entityProp != this.props[property]) {
                throw new TypeError(`Property ${property} is of incorrect type!`)
            }
        }
        return true;
    }
}
// // Initialize props object
// let properties = {
//     name: "string",
//     age: "number",
//     birthday: "object"
// };
// //Initialize the repository
// let repository = new Repository(properties);
// // Add two entities
// let entity = {
//     name: "Kiril",
//     age: 19,
//     birthday: new Date(1998, 0, 7)
// };
// repository.addEntity(entity);
// repository.addEntity(entity);
// console.log(repository.toString());
// //Update an entity
// entity = {
//     name: 'Valio',
//     age: 19,
//     birthday: new Date(1998, 0, 7)
// };
// repository.updateEntity(1, entity);
// console.log(repository.toString());
// // Delete an entity
// repository.deleteEntity(0);
// console.log(repository.toString());
// let anotherEntity = {
//     name1: 'Nakov',
//     age: 26,
//     birthday: new Date(1991, 0, 21)
// };
// try{
//     repository.addEntity(anotherEntity); // should throw an Error
// }
// catch(e) {
//     console.log(e.message)
// }
//
// anotherEntity = {
//     name: 'Nakov',
//     age: 26,
//     birthday: 1991
// };
// try{
//     repository.addEntity(anotherEntity); // should throw a TypeError
// }
// catch(e) {
//     console.log(e.message)
// }
// try{
//     repository.deleteEntity(-1); // should throw Error for invalid id
// }
// catch(e) {
//     console.log(e.message)
// }
//
//
