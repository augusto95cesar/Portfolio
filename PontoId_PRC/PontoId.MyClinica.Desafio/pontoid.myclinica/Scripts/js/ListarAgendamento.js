$('#PesquisarDataStatus').click(function () {

    var dataInicio = $('#dataInicio').val();    
    var dataFinal = $('#dataFim').val();    
    var status = $('#statuSelect option:selected').attr('name');    
    if (dataInicio == '' || dataFinal == '') {
        alert('Preencha uma Data');
        console.log(status);
        console.log(dataFinal);
        console.log(dataInicio);
    }
    else {
       
        $.ajax({        
            type: 'GET',
            url: "/AgendamentoConsultas/ListarAgendamento",
            data: {
                'dtInicio': dataInicio,
                'dtfinal': dataFinal,
                'idStatus': status
            },
            dataType: 'json',
            success: function (response) {                
                if (response == false) {
                    alert('Nenhum Agendamento Marcado');
                } else {
                    console.log(response);
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

                    var thCPF = document.createElement('th');
                    var txCPF = document.createTextNode('CPF');
                    thCPF.appendChild(txCPF);
                    trTitulo.appendChild(thCPF);

                    var thPaciente = document.createElement('th');
                    var txPaciente = document.createTextNode('Paciente');
                    thPaciente.appendChild(txPaciente);
                    trTitulo.appendChild(thPaciente);

                    var thMatricula = document.createElement('th');
                    var txMatricula = document.createTextNode('Matricula');
                    thMatricula.appendChild(txMatricula);
                    trTitulo.appendChild(thMatricula);

                    var thConvenio = document.createElement('th');
                    var txConvenio = document.createTextNode('Convenio');
                    thConvenio.appendChild(txConvenio);
                    trTitulo.appendChild(thConvenio);

                    var thStatus = document.createElement('th');
                    var txStatus = document.createTextNode('Status');
                    thStatus.appendChild(txStatus);
                    trTitulo.appendChild(thStatus);

                    var thBotao = document.createElement('th');
                    var txBotao = document.createTextNode('');
                    thPaciente.appendChild(txBotao);
                    trTitulo.appendChild(thBotao);

                    for (var i = 0; i < response.length; i++) {
                        var trConteudo = document.createElement('tr');
                        Table.appendChild(trConteudo); 
                        var tdClinica = document.createElement('td');
                        var Clinica = document.createTextNode(response[i].clinica);
                        tdClinica.appendChild(Clinica);
                        trConteudo.appendChild(tdClinica);

                        var tdData = document.createElement('td');
                        var Data = document.createTextNode(response[i].dataMarcada);
                        tdData.appendChild(Data);
                        trConteudo.appendChild(tdData);

                        var tdHoras = document.createElement('td');
                        var Horas = document.createTextNode(response[i].horaMarcada);
                        tdHoras.appendChild(Horas);
                        trConteudo.appendChild(tdHoras);

                        var tdCPF = document.createElement('td');
                        var CPF = document.createTextNode(response[i].cpf);
                        tdCPF.appendChild(CPF);
                        trConteudo.appendChild(tdCPF);

                        var tdPaciente = document.createElement('td');
                        var Paciente = document.createTextNode(response[i].nomePaciente);
                        tdPaciente.appendChild(Paciente);
                        trConteudo.appendChild(tdPaciente);

                        var tdMatricula = document.createElement('td');
                        var Matricula = document.createTextNode(response[i].matricula);
                        tdMatricula.appendChild(Matricula);
                        trConteudo.appendChild(tdMatricula);

                        var tdConvenio = document.createElement('td');
                        var Convenio = document.createTextNode(response[i].nomeCovenio);
                        tdConvenio.appendChild(Convenio);
                        trConteudo.appendChild(tdConvenio);

                        if (response[i].status == 0) {
                            var tdStatus = document.createElement('td');
                            var Status = document.createTextNode('Aguardando Atendimento');
                            tdStatus.appendChild(Status);
                            trConteudo.appendChild(tdStatus);
                        }
                        if (response[i].status == 1) {
                            var tdStatus = document.createElement('td');
                            var Status = document.createTextNode('Atendido');
                            tdStatus.appendChild(Status);
                            trConteudo.appendChild(tdStatus);
                        }
                        if (response[i].status == 2) {
                            var tdStatus = document.createElement('td');
                            var Status = document.createTextNode('Nao Compareceu');
                            tdStatus.appendChild(Status);
                            trConteudo.appendChild(tdStatus);
                        }
                        if (response[i].status == 3) {
                            var tdStatus = document.createElement('td');
                            var Status = document.createTextNode('Cancelado PeloUsuario');
                            tdStatus.appendChild(Status);
                            trConteudo.appendChild(tdStatus);
                        }
                        if (response[i].status == 4) {
                            var tdStatus = document.createElement('td');
                            var Status = document.createTextNode('Cancelado PelaClinica');
                            tdStatus.appendChild(Status);
                            trConteudo.appendChild(tdStatus);
                        }

                        //var Botao = document.createElement('button');                           
                        //Botao.setAttribute("name", response[j].Id);
                        //Botao.setAttribute("class", "btn btn-outline-danger");
                        //Botao.setAttribute("value", "Editar");
                        //var Botao = document.createElement('a');
                        //Botao.setAttribute("name", response[j].Id);
                        //Botao.setAttribute("class", "btn btn-outline-danger");
                        //Botao.setAttribute("hr3f", "/AgendamentoConsultas/Edit/" + response[j].Id);

                        //var textBtn = document.createTextNode('Editar');
                        //Botao.appendChild(textBtn);

                        //var tdBotao = document.createElement('td');                            
                        //tdBotao.appendChild(Botao);
                        //trConteudo.appendChild(tdBotao);
                    }

                    var elemento = document.getElementById("MinhaListaAgendamento");
                    while (elemento.firstChild) {
                        elemento.removeChild(elemento.firstChild);
                    }
                    elemento.appendChild(Table); 
                }
            }
        });
    }
});

