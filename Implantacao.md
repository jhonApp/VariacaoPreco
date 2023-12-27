# Configuração do Ambiente com Imagens do Docker Hub, Git Hub e AWS

## Pré-requisitos

Antes de começar, assegure-se de ter instalado:

- Docker Desktop ou Docker Engine
- Conta no Docker Hub (se necessário)

## Passos

#### Repositório Git

### 1. Clone o repositório

- Clone o repositório do projeto:

- git clone https://github.com/jhonApp/VariacaoPreco.git
- cd VariacaoPreco

#### Docker Hub

### 1. Baixe as imagens do Docker Hub

segue o link: https://hub.docker.com/r/jeverton98/variacao-ativos/tags

## Use o comando docker pull para baixar as imagens necessárias do Docker Hub.

- docker pull jeverton98/variacao-ativos:api

### 2. Execute os containers

- docker run -d -p 8080:80 jeverton98/variacao-ativos:api

### 3. Verifique a execução

- docker ps

#### Conexão banco de dados SQL

- A configuração do banco foi realizada no RDS da AWS

- Segue o acesso para o microsoft sql server studio

- server name: variacao-preco.clavpylp4hbr.us-east-1.rds.amazonaws.com
- login: admin
- senha: com113402

se necessario segue o script do banco:

CREATE DATABASE VariacaoAtivo

CREATE TABLE Ativo (
    ID_ativo INT PRIMARY KEY IDENTITY,
	Simbolo VARCHAR(255) NOT NULL,
	Dia INT NOT NULL,
    Data_stamp DATE NOT NULL,
	Valor_baixa FLOAT NULL,
	Valor_alta FLOAT NULL,
	Valor_fechamento FLOAT NULL,
	Valor_abertura FLOAT NULL,
	Volume INT NULL
);






