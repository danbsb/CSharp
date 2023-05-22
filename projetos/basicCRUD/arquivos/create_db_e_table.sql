--criação do container no Docker: docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=devD@niel123" --env MSSQL_AGENT_ENABLED=True --name SQL2022_Staging -p 1401:1433 -d mcr.microsoft.com/mssql/server:2022-latest 

--cria banco de dados
CREATE DATABASE crudPessoas

--cria tabela
CREATE TABLE pessoas (
  id VARCHAR(8) DEFAULT LEFT(CONVERT(VARCHAR(255), NEWID()), 8),
  nome VARCHAR(100) NOT NULL,
  idade DATE,
  cpf VARCHAR(11),
  email VARCHAR(100),
  telefone VARCHAR(20),
  PRIMARY KEY (id)
)

--pessoas para popular a tabela
INSERT INTO pessoas (nome, idade, cpf, email, telefone) VALUES
  ('João da Silva', '1990-05-15', '12345678901', 'joao@example.com', '123456789'),
  ('Maria Souza', '1985-10-20', '98765432101', 'maria@example.com', '987654321'),
  ('Pedro Santos', '1992-02-08', '45678901234', 'pedro@example.com', '456789012'),
  ('Ana Oliveira', '1988-09-12', '54321098765', 'ana@example.com', '543210987'),
  ('Carlos Pereira', '1995-04-25', '67890123456', 'carlos@example.com', '678901234'),
  ('Laura Costa', '1999-07-30', '89012345678', 'laura@example.com', '890123456'),
  ('Marcos Almeida', '1982-11-05', '21098765432', 'marcos@example.com', '210987654'),
  ('Fernanda Lima', '1991-06-18', '76543210987', 'fernanda@example.com', '765432109'),
  ('Rafaela Ferreira', '1987-03-22', '34567890123', 'rafaela@example.com', '345678901'),
  ('Lucas Rocha', '1994-08-07', '43210987654', 'lucas@example.com', '432109876'),
  ('Giovanna Carvalho', '1997-01-11', '87654321098', 'giovanna@example.com', '876543210'),
  ('José Santos', '1983-12-16', '56789012345', 'jose@example.com', '567890123'),
  ('Isabela Pereira', '1998-09-01', '10987654321', 'isabela@example.com', '109876543'),
  ('Thiago Silva', '1993-02-28', '67890543210', 'thiago@example.com', '678905432'),
  ('Beatriz Costa', '1989-07-03', '21098765439', 'beatriz@example.com', '210987654');
