script para criar database no SQL SERVER
<pre>
CREATE DATABASE [FORNECEDORDB]
GO

USE [FORNECEDORDB]
GO

CREATE TABLE [dbo].[FORNECEDOR] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [nome]        NVARCHAR (250)      NULL,
    [cnpj]        NVARCHAR (50)       NULL,
    [especialidade]   NVARCHAR (30)   NULL,
);
</pre>
