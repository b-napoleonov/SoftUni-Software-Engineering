function attachGradientEvents() {
    const gradient = document.getElementById('gradient');
    gradient.addEventListener('mousemove', changeGradient);

    function changeGradient(e) {
        document.getElementById('result').textContent = `${Math.floor(e.offsetX / gradient.clientWidth * 100)}%`;
    }
}