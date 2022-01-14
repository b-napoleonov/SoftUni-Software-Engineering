function solve() {
  let text = document.getElementById('text').value.split(' ');
  let parameter = document.getElementById('naming-convention').value;
  let result = '';
    switch (parameter) {
      case 'Camel Case':
        result += (text[0][0].toLowerCase() + text[0].substring(1).toLowerCase());
        break;
      
      case 'Pascal Case':
        result += (text[0][0].toUpperCase() + text[0].substring(1).toLowerCase());
        break;

      default:
        result = "Error!";
        break;
    }
    if (result != "Error!") {
      for (let i = 1; i < text.length; i++) {
        result += (text[i][0].toUpperCase() + text[i].substring(1).toLowerCase());
      }
    }

  document.getElementById('result').innerHTML = result;
}