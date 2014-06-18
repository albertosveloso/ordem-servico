CREATE DATABASE OrdemServico

use OrdemServico
go

CREATE TABLE tblCliente
(
	IdCliente INT NOT NULL IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	CPF DECIMAL(11,0) NOT NULL,
	DataCadastro DATE NOT NULL

	PRIMARY KEY (IdCliente)
)

CREATE TABLE tblServico
(
	IdServico INT NOT NULL IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	Valor DECIMAL(18,2) NOT NULL,
	DataCadastro DATE NOT NULL

	PRIMARY KEY (IdServico)
)

CREATE TABLE tblClienteEndereco
(
	IdCliente INT NOT NULL,
	Logradouro VARCHAR(200) NOT NULL,
	Numero INT NOT NULL,
	Bairro VARCHAR(100) NOT NULL,
	Cidade VARCHAR(100) NOT NULL,
	CEP DECIMAL(8,0) NOT NULL,

	PRIMARY KEY (IdCliente, Logradouro),
	FOREIGN KEY (IdCliente) REFERENCES tblCliente(IdCliente)
)

CREATE TABLE tblClienteTelefone
(
	IdCliente INT NOT NULL,
	Telefone DECIMAL(18,0)

	PRIMARY KEY (IdCliente, Telefone)
	FOREIGN KEY (IdCliente) REFERENCES tblCliente(IdCliente)
)

CREATE TABLE tblOrdemServico
(
	IdOrdemServico INT NOT NULL IDENTITY,
	DataCadastro DATE NOT NULL,
	IdCliente INT NOT NULL,
	ValorTotal DECIMAL(18,2) NOT NULL

	PRIMARY KEY (IdOrdemServico)
	FOREIGN KEY (IdCliente) REFERENCES tblCliente(IdCliente)
)

CREATE TABLE tblOrdemServicoItem
(
	IdOrdemServico INT NOT NULL,
	IdServico INT NOT NULL,
	ValorTotal DECIMAL(18,2) NOT NULL

	Primary key (IDOrdemServico, IdServico)
	FOREIGN KEY (IDOrdemServico) REFERENCES tblOrdemServico(IdOrdemServico),
	FOREIGN KEY (IDServico) REFERENCES tblServico(IdServico)
)







