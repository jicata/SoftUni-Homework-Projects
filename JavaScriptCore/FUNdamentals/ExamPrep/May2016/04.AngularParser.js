/*jshint esversion: 6 */
function angularParser(data) {
    "use strict";
    data.pop();
    let modulesAndControllers = new Map();
    let modulesAndModels = new Map();
    let modulesAndView = new Map();

    let storedElements = new Map();

    for (let i = 0; i < data.length; i++) {
        let dataDetails = data[i].split("&");
        let firstElementPair = dataDetails[0];
        let elementName = firstElementPair.split("=")[1].replace(/'/g, (match) => "");
        if (dataDetails.length == 1) {
            if (!modulesAndControllers.has(elementName)) {
                modulesAndControllers.set(elementName, {controllers: [], models: [], views: []});
            }
            if (storedElements.has(elementName)) {
                let elements = storedElements.get(elementName);
                for (let element of elements) {
                    let storedElementDetails = element.split('=');
                    let storedElementType = storedElementDetails[0];
                    let storedElementName = storedElementDetails[1];
                    AddElementToElementsOfModule(storedElementType, storedElementName, elementName, modulesAndControllers);
                }
            }
            continue;
        }
        let elementType = firstElementPair.split("=")[0].replace(/\$/g, (match) => "");

        let modulePair = dataDetails[1];
        let moduleName = modulePair.split("=")[1].replace(/'/g, (match) => "");

        if (!modulesAndControllers.has(moduleName)) {
            let elementTypeAndValue = `${elementType}=${elementName}`;
            let storedElementsByModule = [];
            if (!storedElements.has(moduleName)) {
                storedElementsByModule.push(elementTypeAndValue);
                storedElements.set(moduleName, storedElementsByModule);
                continue;
            }
            storedElementsByModule = storedElements.get(moduleName);
            storedElementsByModule.push(elementTypeAndValue);
            storedElements.set(moduleName, storedElementsByModule);

            continue;
        }
        let elementsOfModule = AddElementToElementsOfModule(elementType, elementName, moduleName, modulesAndControllers);
    }

    let sortedModules = Array.from(modulesAndControllers).sort((a, b) => sortModules(a, b));


    let resultObject={};
    for (let [moduleName, moduleElements] of sortedModules) {
        let controllers = moduleElements.controllers.sort((a, b) => alphabeticalSort(a, b));
       let models =  moduleElements.models.sort((a, b) => alphabeticalSort(a, b));
       let views =  moduleElements.views.sort((a, b) => alphabeticalSort(a, b));
        let result = {
            moduleName: {
                controllers: moduleElements.controllers,
                models: moduleElements.models,
                views: moduleElements.views
            }
        };
        resultObject[moduleName] = {controllers,models, views};
    }
    console.log(JSON.stringify(resultObject));
    function alphabeticalSort(a, b) {
        return a.localeCompare(b);
    }

    function sortModules(moduleA, moduleB) {
        let moduleAElements = moduleA[1];
        let moduleBElements = moduleB[1];
        if (moduleAElements.controllers.length > moduleBElements.controllers.length) {
            return -1;
        }
        if (moduleAElements.controllers.length < moduleBElements.controllers.length) {
            return 1;
        }
        if (moduleAElements.models.length > moduleBElements.models.length) {
            return 1;
        }
        if (moduleAElements.models.length < moduleBElements.models.length) {
            return -1;
        }


    }

    function AddElementToElementsOfModule(elementType, elementName, moduleName, modulesAndControllers) {
        let elementsOfModule = modulesAndControllers.get(moduleName);

        switch (elementType) {
            case "controller":
                elementsOfModule.controllers.push(elementName)
                break;
            case "model":
                elementsOfModule.models.push(elementName)
                break;
            default:
                elementsOfModule.views.push(elementName);

        }
        modulesAndControllers.set(moduleName, elementsOfModule);
        //return elementsOfModule;
    }
}
// angularParser(["$app='MyApp'",
//     "$controller='My Controller'&app='MyApp'",
//     "$model='My Model'&app='MyApp'",
//     "$view='My View'&app='MyApp'"]);

// angularParser(["$controller='PHPController'&app='Language Parser'",
//     "$controller='JavaController'&app='Language Parser'",
//     "$controller='C#Controller'&app='Language Parser'",
//     "$controller='C++Controller'&app='Language Parser'",
//     "$app='Garbage Collector'",
//     "$controller='GarbageController'&app='Garbage Collector'",
//     "$controller='SpamController'&app='Garbage Collector'",
//     "$app='Language Parser'"]);