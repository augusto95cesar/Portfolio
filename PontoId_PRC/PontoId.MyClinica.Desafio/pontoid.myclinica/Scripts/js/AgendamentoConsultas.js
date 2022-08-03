$('#cpfJsonId').focusout(function ()
{
    BuscarCpf();
});

$('#ClinicaSelect').focusout(function (e)
{
    e.preventDefault();
    var CPF = $('#cpfJsonId').val();    
    if (CPF == "") {
        $('#cpfJsonId').focus();
    }
});

$('#SalvarPaciente').click(function ()
{
    var nomepaciente = $('#pacienteJsonId').val();
    var telefone = $('#telefoneJsonId').val();
    var email = $('#emailJsonId').val();
    var cpf = $('#cpfJsonId').val();
    var matricula = $('#idmatricula').val();
    var cod = $('#convenioJsonDrop').val();
    
    $.ajax({
        type: 'POST',
        url: "/AgendamentoConsultas/CadastrarPaciente",
        data: {
            "nomepaciente": nomepaciente,
            "telefone": telefone,
            "email": email,
            "cpf": cpf,
            "matricula": matricula,
            "cod":cod
        },
        dataType: 'json',
        success: function (responseConvenio)
        {
            BuscarCpf();
        }
    });
});

function buscarData()
{
    var idClinca = $('#ClinicaSelect').val();
    var idPaciente = $('#cpfJsonId').attr('name'); 

    //console.log("Valor do name:" + idPaciente);
    
    $.ajax({
        type: 'GET',
        url: "/AgendamentoConsultas/ListarDatas",
        data: {
            "idClinca": idClinca,
            "idPaciente": idPaciente             
        },
        dataType: 'json',
        success: function (response) {
            //console.log(response);
            if (response == false)
            {
                alert("Não Tem Vaga Para a Clinica Selecionada");
            }
            else
            {
                var select = document.createElement('select');
                select.setAttribute("class", "form-control");
                select.setAttribute("id", "selectData");

                for (var i = 0; i < response.length; i++) {
                    var op = document.createElement('option');
                    var text = document.createTextNode(response[i].dataConsulta);
                    //console.log(response[i].dataConsulta);
                    op.setAttribute("values", response[i].id);
                    op.appendChild(text);
                    select.appendChild(op);
                }
                var elemento = document.getElementById("DataAgendamento");
                while (elemento.firstChild) {
                    elemento.removeChild(elemento.firstChild);
                }
                elemento.appendChild(select);
                 
            }
        }
    });       
}

function BuscarCpf() {
    var CPF = $('#cpfJsonId').val();
    if (CPF == "") {
        alert("CPF Não Encontrado");
    }
    else {
        $.ajax({
            type: 'GET',
            url: "/AgendamentoConsultas/ListaPaciente",
            data: { "idCpf": CPF },
            dataType: 'json',
            success: function (response) {
                if (response == false)
                {
                    alert("Cpf Não Cadastrado");
                    $('#pacienteJsonId').val('');
                    $('#telefoneJsonId').val('');
                    $('#emailJsonId').val('');
                    $('#pacienteJsonId').prop("disabled", false);
                    $('#telefoneJsonId').prop("disabled", false);
                    $('#emailJsonId').prop("disabled", false);
                    $('#notConvenio').css("display", "none");
                    $('#Cadastrar').css("display", "");
                    $('#TemConvenio').css("display", "none");
                }
                else
                {                     
                    $('#cpfJsonId').prop('name', response.id);
                    $('#pacienteJsonId').val(response.nome);
                    $('#telefoneJsonId').val(response.telefone);
                    $('#emailJsonId').val(response.matricula);
                    $('#pacienteJsonId').prop("disabled", true);
                    $('#telefoneJsonId').prop("disabled", true);
                    $('#emailJsonId').prop("disabled", true);

                    if (response.idcovenio == "") {
                        $('#notConvenio').css("display", "none");
                        $('#Cadastrar').css("display", "none");
                        $('#TemConvenio').css("display", "");
                        $('#TemConvenioMatricula').val("Particular");
                        $('#TemConvenioNome').css("display", "none");
                    }
                    else
                    {
                        $.ajax(
                        {
                            type: 'GET',
                            url: "/AgendamentoConsultas/ListarConvenio",
                                data: { "idConvenio": response.idcovenio },
                            dataType: 'json',
                            success: function (responseConvenio)
                            {                             
                                $('#notConvenio').css("display", "none");
                                $('#Cadastrar').css("display", "none");
                                $('#TemConvenio').css("display", "");
                                $('#TemConvenioMatricula').val(response.matricula);
                                $('#TemConvenioNome').val(responseConvenio.NomeConvenio);
                            }
                        });
                    }
                    buscarData();
                }//fim Ajax Primeiro              
            }
        });
    }
};

$('#DataAgendamento').focusout(function ()
{     
    var data = $('#selectData option:selected').text();  
    var idClinca = $('#ClinicaSelect').val();
    var pacienteid = $('#cpfJsonId').attr("name");
    $.ajax({
        type: 'GET',
        url: "/AgendamentoConsultas/ListarHora",
        data: {
            "idClinca": idClinca,
            "idPaciente": pacienteid,
            "idData": data
        },
        dataType: 'json',
        success: function (response) {
            //console.log("Horas:");
            if (response == false) {
                alert("O CPF:" + cpf + " Possui uma Consulta nesse dia");
            } else {

                var select = document.createElement('select');
                select.setAttribute("class", "form-control");
                select.setAttribute("id", "selectHora");
                var qtvagas = response.length;
                $("#qtVagas").val(qtvagas)
                for (var i = 0; i < response.length; i++) {
                    var op = document.createElement('option');
                    var text = document.createTextNode(response[i].horas);
                    //console.log(response[i].horas);
                    op.setAttribute('name', response[i].id);
                    op.appendChild(text);
                    select.appendChild(op);
                }
                var elemento = document.getElementById("HoraAgendamento");
                while (elemento.firstChild) {
                    elemento.removeChild(elemento.firstChild);
                }
                elemento.appendChild(select);             
            }
        }
    });
});

$('#CadastraAgendamento').click(function () {

    var vagas = $('#selectHora option:selected').attr("name");
    //console.log(vagas);
    var pacienteid = $('#cpfJsonId').attr("name");
    
    if (vagas == null) {
        alert("Selecione a Data");
    } else {
        $.ajax({
            type: 'POST',
            url: "/AgendamentoConsultas/CadastrarAgendamento",
            data: {
                "idPaciente": pacienteid,
                "idVaga": vagas
            },
            dataType: 'json',
            success: function (response) {
                console.log(response);
                document.getElementById("agendamentoConcluido").innerHTML = "";
                alert("Agendamento Feito Com Sucesso");
            }
        });
    }
});