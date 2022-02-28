async function getInfo() {
    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    const stopNameDiv = document.getElementById('stopName');
    const busesDiv = document.getElementById('buses');

    try {
        stopNameDiv.textContent = 'Loading...';
        busesDiv.replaceChildren();

        const response = await fetch(url);
        if (response.status !== 200) {
            throw new Error('Error')
        }

        const data = await response.json();
        stopNameDiv.textContent = data.name;

        Object.entries(data.buses).forEach(([busId, bus]) => {
            const liElement = document.createElement('li');
            liElement.textContent = `Bus ${busId} arrives in ${bus.minutes} minutes`;
            busesDiv.appendChild(liElement);
        });

    } catch (error) {
        stopNameDiv.textContent = `${error.message}`;
    }
}