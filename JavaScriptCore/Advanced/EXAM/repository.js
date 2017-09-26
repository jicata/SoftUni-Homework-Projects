let Repository = (() => {
    let id = 0;
    return class Repository {
        constructor(props) {
            this.props = props;
            this.data = new Map;
        }

        addEntity(entity) {
            this.validateEntity(entity);
            this.data.set(id++, entity);
        }

        updateEntity(id, newEntity) {
            if(!this.data.has(id)){
                throw new Error(`Entity with id: ${id} does not exist!`);
            }

            this.validateEntity(newEntity);
            this.data.set(id, newEntity);
        }

        deleteEntity(id) {
            if(!this.data.has(id)){
                throw new Error(`Entity with id: ${id} does not exist!`);
            }

            this.data.delete(id);
        }

        validateEntity(entity) {
            //Validate existing property
            for(let propName in this.props) {
                if(!entity.hasOwnProperty(propName)){
                    throw new Error(`Property ${propName} is missing from the entity!`);
                }
            }

            //Validate property type
            for(let propName in entity) {
                let val = entity[propName];
                if(typeof val !== this.props[propName]){
                    throw new TypeError(`Property ${propName} is not of correct type!`);
                }
            }
        }

        toString() {
            let result = '';
            for(let [id, entity] of this.data) {
                result += `${id}: ${JSON.stringify(entity)}\n`;
            }

            return result.trim();
        }
    }

})()

// Initialize props object
let properties = {
    name: "string",
    age: "number",
    birthday: "object"
};

//Initialize the repository
let repository = new Repository(properties);

// Add two entities
let entity = {
    name: "Kiril",
    age: 19,
    birthday: new Date(1998, 0, 7)
};

repository.addEntity(entity);
repository.addEntity(entity);
console.log(repository.toString());

//Update an entity
entity = {
    name: 'Valio',
    age: 19,
    birthday: new Date(1998, 0, 7)
};
repository.updateEntity(1, entity);
console.log(repository.toString());

// Delete an entity
repository.deleteEntity(0);
console.log(repository.toString());

