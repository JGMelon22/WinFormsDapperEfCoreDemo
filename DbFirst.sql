-- Creates Database
CREATE DATABASE WinFormsDemoDb;
GO

-- Pessoas definition
CREATE TABLE Pessoas (
	PessoaId int IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Pessoas PRIMARY KEY (PessoaId)
);
GO

 CREATE NONCLUSTERED INDEX IX_Pessoas_PessoaId ON Pessoas (  PessoaId ASC  )  
	 

-- Telefones definition
CREATE TABLE Telefones (
	TelefoneId int IDENTITY(1,1) NOT NULL,
	TelefoneTexto nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Ativo bit NOT NULL,
	PessoaId int NOT NULL,
	CONSTRAINT PK_Telefones PRIMARY KEY (TelefoneId)
);
GO
	
-- Detalhes definition
CREATE TABLE Detalhes (
	DetalheId int IDENTITY(1,1) NOT NULL,
	DetalheTexto varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PessoaId int NOT NULL,
	CONSTRAINT PK_Detalhes PRIMARY KEY (DetalheId),
	CONSTRAINT FK_Detalhes_Pessoas_PessoaId FOREIGN KEY (PessoaId) REFERENCES Pessoas(PessoaId) ON DELETE CASCADE
);
GO

-- PessoaTelefone definition

CREATE TABLE PessoaTelefone (
	PessoasPessoaId int NOT NULL,
	TelefonesTelefoneId int NOT NULL,
	CONSTRAINT PK_PessoaTelefone PRIMARY KEY (PessoasPessoaId,TelefonesTelefoneId),
	CONSTRAINT FK_PessoaTelefone_Pessoas_PessoasPessoaId FOREIGN KEY (PessoasPessoaId) REFERENCES Pessoas(PessoaId) ON DELETE CASCADE,
	CONSTRAINT FK_PessoaTelefone_Telefones_TelefonesTelefoneId FOREIGN KEY (TelefonesTelefoneId) REFERENCES Telefones(TelefoneId) ON DELETE CASCADE
);
GO

-- Create Indexes
CREATE NONCLUSTERED INDEX IX_PessoaTelefone_TelefonesTelefoneId 
	ON PessoaTelefone (  TelefonesTelefoneId ASC  );
GO

CREATE NONCLUSTERED INDEX IX_Detalhes_DetalheId 
	ON Detalhes (  DetalheId ASC  );
GO 

CREATE NONCLUSTERED INDEX IX_Detalhes_PessoaId 
	ON Detalhes (  PessoaId ASC  )  
GO

CREATE NONCLUSTERED INDEX IX_Telefones_TelefoneId 
	ON Telefones (  TelefoneId ASC  )  
GO