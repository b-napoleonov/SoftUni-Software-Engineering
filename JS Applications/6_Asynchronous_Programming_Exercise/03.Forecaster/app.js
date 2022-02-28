const labelDiv = document.querySelector('.label');
const forecastDiv = document.getElementById('forecast');
const currentDiv = document.getElementById('current');
const upcomingDiv = document.getElementById('upcoming');
const specialSymbols = {
    'Sunny': '&#x2600;',
    'Partly sunny': '&#x26C5;',
    'Overcast': '&#x2601;',
    'Rain': '&#x2614;',
    'Degrees': '&#176;'
};

function attachEvents() {
    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', getWeather);
}

async function getWeather(ev) {
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    const location = document.getElementById('location').value;

    if (location != '') {
        try {
            forecastDiv.style.display = 'block';
            currentDiv.removeChild(currentDiv.lastChild);
            upcomingDiv.removeChild(upcomingDiv.lastChild);
            ev.target.disabled = true;

            const response = await fetch(url);
            if (response.status !== 200) {
                throw new Error('Error');
            }

            const data = await response.json();
            const locationData = data.find(x => x.name === location);

            const currentWeather = await getCurrentWeather(locationData.code);
            const threeDayForecast = await getThreeDayForecast(locationData.code);
            console.log(threeDayForecast);

            displayCurrentWeather(currentWeather);
            displayThreeDayForecast(threeDayForecast);
            ev.target.disabled = false;

        } catch (error) {
            labelDiv.textContent = `${'Error'}`;
        }
    }
}

async function getCurrentWeather(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    try {
        const response = await fetch(url);
        if (response.status !== 200) {
            throw new Error('Error');
        }

        const data = await response.json();
        return data;

    } catch (error) {
        console.log(error);
    }
}

async function getThreeDayForecast(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
    try {
        const response = await fetch(url);
        if (response.status !== 200) {
            throw new Error('Error');
        }

        const data = await response.json();
        return data;

    } catch (error) {
        console.log(error);
    }
}

function displayCurrentWeather(currentWeather) {
    const location = currentWeather.name;
    const degrees = currentWeather.forecast.low + '\xB0' + ' - ' + currentWeather.forecast.high + '\xB0';
    const weather = currentWeather.forecast.condition;
    const symbol = specialSymbols[weather];

    const weatherSymbol = e('span', { class: 'condition symbol' });
    weatherSymbol.innerHTML = symbol;

    const forecastDiv = e('div', { class: 'forecasts' },
        weatherSymbol,
        e('span', { class: 'condition' },
            e('span', { class: 'forecast-data' }, location),
            e('span', { class: 'forecast-data' }, degrees),
            e('span', { class: 'forecast-data' }, weather)));

    currentDiv.appendChild(forecastDiv);
}

function displayThreeDayForecast(threeDayForecast) {
    const forecastInfoDiv = e('div', { class: 'forecast-info' });

    threeDayForecast.forecast.forEach(x => {
        const symbol = specialSymbols[x.condition];
        const degrees = x.low + '\xB0' + ' - ' + x.high + '\xB0';
        const weather = x.condition;

        const weatherSymbol = e('span', { class: 'symbol' });
        weatherSymbol.innerHTML = symbol;

        const forecastSpan = e('span', { class: 'upcoming' },
            weatherSymbol,
            e('span', { class: 'forecast-data' }, degrees),
            e('span', { class: 'forecast-data' }, weather));

        forecastInfoDiv.appendChild(forecastSpan);
    });

    upcomingDiv.appendChild(forecastInfoDiv);
}

function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (let prop in attr) {
        element.setAttribute(prop, attr[prop]);
    }

    for (let item of content) {
        if (typeof item === 'string' || typeof item === 'number') {
            item = document.createTextNode(item);
        }
        element.appendChild(item);
    }

    return element;
}

attachEvents();