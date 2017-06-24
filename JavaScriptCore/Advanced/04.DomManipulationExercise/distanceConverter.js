/*jshint esversion: 6 */
function attachEventsListeners() {
    let convertBtn = document.getElementById('convert');
    convertBtn.addEventListener('click', convertShit);

    function convertShit() {
        let fromAmount = Number(document.getElementById('inputDistance').value);
        let toTarget = document.getElementById('outputDistance');

        let from = document.getElementById('inputUnits');
        let to = document.getElementById('outputUnits');

        let rates = [
            1000,
            1,
            0.01,
            0.001,
            1609.34,
            0.9144,
            0.3048,
            0.0254,
        ];

        let result = (fromAmount * rates[from.selectedIndex]) / rates[to.selectedIndex];
        toTarget.value = result;
    }
}
