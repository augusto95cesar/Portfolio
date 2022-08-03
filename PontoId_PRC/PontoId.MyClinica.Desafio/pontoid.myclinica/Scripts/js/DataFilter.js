$('#PesquisarDataFilter').click(function () {

    var dataInicio = $('#DataInicioData').val();
    var dataFinal = $('#DataFimData').val();
    var status = $('#DataSelectData option:selected').attr('name');
    if (dataInicio == '' || dataFinal == '') {
        alert('Preencha uma Data');
        console.log(status);
        console.log(dataFinal);
        console.log(dataInicio);
    }
    else {

        $.ajax({
            type: 'GET',
            url: "/vagas/IndexList",
            data: {
                'dataInicio': dataInicio,
                'dataFim': dataFinal,
                'idclinica': status
            },
            dataType: 'json',
            success: function (response) {
                //console.log(response);
                if (response == false)
                {
                    alert('Nenhum Agendamento Marcado');
                }
                else
                {
                    //console.log(response);
                    var Table = document.createElement('table');
                    Table.setAttribute("class", "table");

                    var trTitulo = document.createElement('tr');
                    Table.appendChild(trTitulo);

                    var thClinica = document.createElement('th');
                    var txClinica = document.createTextNode('Clinica');
                    thClinica.appendChild(txClinica);
                    trTitulo.appendChild(thClinica);

                    var thData = document.createElement('th');
                    var txData = document.createTextNode('Data');
                    thData.appendChild(txData);
                    trTitulo.appendChild(thData);

                    var thHoras = document.createElement('th');
                    var txHoras = document.createTextNode('Horas');
                    thHoras.appendChild(txHoras);
                    trTitulo.appendChild(thHoras); 

                    for (var i = 0; i < response.length; i++)
                    {
                        var trConteudo = document.createElement('tr');  
                        var tdClinica = document.createElement('td');
                        var Clinica = document.createTextNode(response[i].NomeClinica);
                        tdClinica.appendChild(Clinica);
                        trConteudo.appendChild(tdClinica);

                        var tdData = document.createElement('td');
                        var Data = document.createTextNode(response[i].DataString);
                        tdData.appendChild(Data);
                        trConteudo.appendChild(tdData);

                        var tdHoras = document.createElement('td');
                        var Horas = document.createTextNode(response[i].HoraString);
                        tdHoras.appendChild(Horas);
                        trConteudo.appendChild(tdHoras); 
                        Table.appendChild(trConteudo);   
                    }

                    var elemento = document.getElementById("DataFilter");
                    document.getElementById("DataFilter").innerHTML = "";
                    while (elemento.firstChild) {
                        elemento.removeChild(elemento.firstChild);
                    }
                    elemento.appendChild(Table);
                }
            }
        });
    }
});