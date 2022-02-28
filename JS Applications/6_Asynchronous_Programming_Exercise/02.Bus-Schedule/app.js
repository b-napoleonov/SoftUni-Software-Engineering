function solve() {
    const infoField = document.querySelector('#info');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    let stopId = 'depot';

    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stopId}`;
        
        try {
            infoField.textContent = 'Loading...';

            const response = await fetch(url);
            if (response.status !== 200) {
                throw new Error('Error');
            }

            const data = await response.json();

            departBtn.disabled = true;
            arriveBtn.disabled = false;
            infoField.textContent = `Next stop ${data.name}`;

        } catch (error) {
            infoField.textContent = `${error.message}`;
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    async function arrive() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stopId}`;

        try {
            infoField.textContent = 'Loading...';

            const response = await fetch(url);
            if (response.status !== 200) {
                throw new Error('Error');
            }

            const data = await response.json();

            departBtn.disabled = false;
            arriveBtn.disabled = true;
            stopId = data.next;
            infoField.textContent = `Arriving at ${data.name}`;

        } catch (error) {
            infoField.textContent = `${error.message}`;
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();