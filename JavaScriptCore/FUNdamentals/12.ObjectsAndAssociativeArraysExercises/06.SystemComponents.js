/*jshint esversion: 6 */
function systemComponents(systemsData) {
    let systems = new Map();
    for(let systemInfo of systemsData){
        let systemInfoSplit = systemInfo.split(' | ').filter(String);

        let systemName = systemInfoSplit[0];
        let componentName = systemInfoSplit[1];
        let subcomponentName = systemInfoSplit[2];

        let components = new Map();
        let subcomponents = [];

        if(systems.has(systemName)){

            if(systems.get(systemName).has(componentName)){
                subcomponents = systems.get(systemName).get(componentName);
                subcomponents.push(subcomponentName);

                components = systems.get(systemName);
                components.set(componentName,subcomponents);

            }
            else{
                subcomponents.push(subcomponentName);

                components = systems.get(systemName);
                components.set(componentName, subcomponents);
            }
            systems.set(systemName,components);
        }
        else{
            subcomponents.push(subcomponentName);
            components.set(componentName, subcomponents);
            systems.set(systemName,components);
        }
    }

    let sortedSystems = Array.from(systems).sort( (s1, s2) => filterByAmountOfComponents(s1, s2));
    for(let [system,components] of sortedSystems){
        console.log(system);
        let sortedComponents = Array.from(components).sort( (c1, c2) => c2[1].length - c1[1].length);

        for(let [component, subcomponents] of sortedComponents){
            console.log("|||"+component);
            for(let subcomponent of subcomponents){
                console.log("||||||"+subcomponent);
            }
        }
    }

    function filterByAmountOfComponents(s1,s2){

        if (s1[1].size > s2[1].size)
            return -1;
        if (s1[1].size < s2[1].size)
            return 1;
        if (s1[0].toLowerCase() < s2[0].toLowerCase())
            return -1;
        if (s1[0].toLowerCase() > s2[0].toLowerCase())
            return 1;
        return 0;
    }
}
systemComponents(['Iris | Main System | Radiation Reducer',
    'Iris | Main System | Blue Light Reducer',
    'Iris | Sub-System Alpha | Resistor Level-5',
    'Iris | Core | Memory Reducer',
    'Iris | Core | Electricity Reducer',
    'Iris | Sub-System Gamma | Resistor Level-2',
    'Iris | Sub-System Gamma | Resistor Level-3',
    'Iris | Main System | Interface']
);