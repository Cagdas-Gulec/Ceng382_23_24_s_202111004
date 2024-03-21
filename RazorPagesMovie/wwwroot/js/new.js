
function myfunc() {
    var elements = document.querySelectorAll('*');
    elements.forEach(function(element) {
        element.style.display = 'none';
    });
}