## C# - Developer 

Parabéns, você passou para a segunda fase do processo seletivo da MáximaTech para desenvolvedor C# (.Net + Angular).

## Instruções

1. Criar um fork deste repositório, transformar ele em privado, adicionar o nosso usuário (talentosmaxima) como colaborador e implementar o aplicativo conforme instruções abaixo.
2. Enviar um e-mail para <talentoshumanos@maximatech.com.br> com:
	* Assunto "[Teste Desenvolvedor C#] - Nome do candidato"
	* Link: -> Repositório privado no Github.

É hora do show!

## Resumo

Você foi escolhido para escrever uma tela de Cadastro de Produtos (CRUD) que faz parte do módulo de administração de um e-commerce.

O usuário após logar no sistema selecionará a opção "Produto" no menu "Cadastros" na barra de menus.

## Requisitos

* A stack de tecnologia a ser utilizada é C# .NET Core + Angular 6 ou Superior
* O sistema é composto por 2 microsserviços: Serviço Web (Angular) + Serviço Api  (.Net Core)
* Banco de dados - PostgreSQL ou MySQL - Todas as informações precisam ser persistidas no banco de dados escolhido
* Construir um agendamento para consultar os departamentos dos produtos no endpoint especificado na sessão [API com os Departamentos](#api-de-departamentos) 
* Documento descrevendo o processo de instalação do sistema
* O fluxo de autenticação é opcional, o mesmo poderá ser mockado para andamento do projeto

### Detalhamento

* Segue uma sugestão de layout ![alt aqui](https://github.com/talentosmaxima/CSharp-Developer-CRUD/blob/main/Mock%20Tela.png?raw=true)
* Quando o usuário clicar no botão Editar, coluna Ações, o usuário será direcionado para a tela de Edição.
* Campos da Tela
  * ID           - Identificador do Produto       -  UUID
  * Código       - Código apresentável ao usuário -  Texto
  * Descrição    - Descrição do Produto           -  Texto
  * Departamento - Lista de departamentos         -  Caixa de Seleção
  * Preço        - Preço do Produto               -  Decimal
  * Status       - Ativo / Inativo                -  True/False - Booleano
  * Ações        - Editar / Excluir               -  A exclusão é lógica e não física

## API de Departamentos
A lista de departamentos está disponível via API. A documentação da API está no [Apiary](https://maximatech.docs.apiary.io/#reference/0/fullstack/departamento)

## Diferenciais

* Desenho Arquitetural
* Escrita de testes

## Critérios de Avaliação

* Organização do projeto
* Utilização de padrões arquiteturais
* Clean Code
* Ausência de crashs e bugs
* Detalhes de UI

## Dúvidas
Entre em contato com talentoshumanos@maximatech.com.br
