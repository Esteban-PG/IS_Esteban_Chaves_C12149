let fondoCambiado = false;

function agregar() {
    let lista = document.getElementById("lista");
    let numElementos = lista.getElementsByTagName("li").length;
    let nuevoElemento = document.createElement("li");
    nuevoElemento.textContent = "Elemento" + (numElementos + 1);
    lista.appendChild(nuevoElemento);
}

function borrar() {
    let lista = document.getElementById("lista");
    let elementos = lista.getElementsByTagName("li");
    if (elementos.length > 0) {
        lista.removeChild(elementos[elementos.length - 1]);
    }
}

function cambiarFondo() {
    if (fondoCambiado) {
        document.body.style.backgroundColor = "white";
    } else {
        document.body.style.backgroundColor = "#000080";
    }
    fondoCambiado = !fondoCambiado;
}
