CREATE TABLE [dbo].[Funicionario] (
    [FuncionarioId] INT             IDENTITY (1, 1) NOT NULL,
    [Nome]          VARBINARY (100) NOT NULL,
    [Idade]         INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([FuncionarioId] ASC)
);