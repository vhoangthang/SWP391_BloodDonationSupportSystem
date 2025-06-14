window.onload = function () {
  const selectAge = document.getElementById("age");
  for (let i = 18; i <= 59; i++) {
    const option = document.createElement("option");
    option.value = i;
    option.text = i;
    selectAge.appendChild(option);
  }
};