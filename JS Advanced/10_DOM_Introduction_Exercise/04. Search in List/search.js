function search() {
  const listItems = document.querySelectorAll("#towns>li");
  const searchInput = document.querySelector("#searchText");
  const result = document.querySelector("#result");

  let matches = 0;
  for (const element of listItems) {
    const value = element.textContent.toLowerCase();
    if (value.includes(searchInput.value.toLowerCase())) {
      element.style.textDecoration = "underline";
      element.style.fontWeight = "bold";
      matches++;
    } 
    else {
      result.textContent = "";
      element.style.textDecoration = "none";
      element.style.fontWeight = "normal";
    }
  }

  result.textContent = `${matches} matches found`;
}
