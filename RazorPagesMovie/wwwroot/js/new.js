function toggleElements() {
    var element = document.getElementById("toggleElement");
    if (element.style.display === "none") {
        element.style.display = "";
    } else {
        element.style.display = "none";
    }
}

function calculate() {
    event.preventDefault();
    var input1 = document.getElementById("input1").value;
    var input2 = document.getElementById("input2").value;
    var result = parseInt(input1) + parseInt(input2);
    document.getElementById("result").innerHTML = "Result: " + result;
}