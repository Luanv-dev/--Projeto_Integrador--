const apiUrl = 'https://localhost:7011/api/Login';

window.onload = function () {
    registrarEventoCliqueBotao();
};


function registrarEventoCliqueBotao() {
    var elemento = document.getElementById('botaoLogin');

    elemento.addEventListener("click", enviarFormularioLogin);
}

function enviarFormularioLogin() {
    fazerChamadaHttp();
}


function fazerChamadaHttp() {
    var http = new XMLHttpRequest();
    var url = apiUrl;
    var formParams = {
        email: document.getElementById("inputEmail").value,
        senha: document.getElementById("inputSenha").value
    };
    http.open('POST', url, true);

    
    http.setRequestHeader('Content-type', 'application/json');

    http.onreadystatechange = function () {//Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
            var elementoMensagem = document.getElementById('mensagem');
            elementoMensagem.style.display = "block";
            elementoMensagem.innerText = http.responseText;
            //alert(http.responseText);
        }
    }
    var data = JSON.stringify(formParams);
    http.send(data);
}