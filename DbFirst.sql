-- Creates Database
CREATE DATABASE WinFormsDemoDb;
GO

-- Pessoas definition
CREATE TABLE Pessoas (
	PessoaId INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Pessoas PRIMARY KEY (PessoaId)
);
GO

-- Telefones definition
CREATE TABLE Telefones (
	TelefoneId INT IDENTITY(1,1) NOT NULL,
	TelefoneTexto VARCHAR(11) NOT NULL,
	PessoaId INT NOT NULL,
	Ativo BIT NOT NULL,
	CONSTRAINT PK_Telefones PRIMARY KEY (TelefoneId)
);
GO

-- PessoaTelefone definition
CREATE TABLE PessoaTelefone (
	PessoasPessoaId INT NOT NULL,
	TelefonesTelefoneId INT NOT NULL,
	CONSTRAINT PK_PessoaTelefone PRIMARY KEY (PessoasPessoaId,TelefonesTelefoneId),
	CONSTRAINT FK_PessoaTelefone_Pessoas_PessoasPessoaId FOREIGN KEY (PessoasPessoaId) REFERENCES Pessoas(PessoaId) ON DELETE CASCADE,
	CONSTRAINT FK_PessoaTelefone_Telefones_TelefonesTelefoneId FOREIGN KEY (TelefonesTelefoneId) REFERENCES Telefones(TelefoneId) ON DELETE CASCADE
);
GO

-- Create Index
CREATE INDEX IX_PessoaTelefone_TelefonesTelefoneId 
	ON PessoaTelefone;
GO