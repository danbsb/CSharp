using Azure.Core;
using basicCrud;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Criado por: Daniel Fontinele da Silva
Data: 22/05/2023
GitHUB: github.com/danbsb
E-mail: daniel.fontinele@gmail.com
*/

namespace basicCRUD.model
{
    class DBCRUD : Program 
    {
        //cria a string de conexao privada
        private const string connectionString = "Server = localhost, 1401; Database = crudPessoas; User ID = sa; Password = devD@niel123; TrustServerCertificate=True";
        public void Create()
        {
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("");
            Console.WriteLine("Digite o NOME COMPLETO sem acentos,");
            Console.WriteLine("ponto ou cedilha: ");
            var nome = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Digite o CPF (somente nº): ");
            var cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Digite o NASCIMENTO dd/mm/aaaa: ");
            var nascimento = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Digite seu E-MAIL: ");
            var email = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Digite seu TELEFONE: ");
            var telefone = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            

            //cria a Query do SQL
            var insertSQL = "INSERT INTO [pessoas] VALUES (@id, @nome, @idade, @cpf, @email, @telefone)";

            //gerador de GuiID somente 8 primeiros números
            Guid guid = Guid.NewGuid();
            string guidString = guid.ToString();
            string primeiros8Caracteres = guidString.Substring(0, 8);

            //cria pessoa com os dados a serem inseridos
            var pessoa = new TablePessoas();
            pessoa.id = primeiros8Caracteres;
            pessoa.nome = nome;
            pessoa.idade = DateTime.Parse(nascimento);
            pessoa.cpf = cpf;
            pessoa.email = email;
            pessoa.telefone = telefone;

            Console.WriteLine("Os dados estão corretos? ");
            Console.WriteLine("");
            Console.WriteLine(nome);
            Console.WriteLine(cpf);
            Console.WriteLine(nascimento);
            Console.WriteLine(email);
            Console.WriteLine(telefone);
            Console.WriteLine("");
            Console.WriteLine("[0 = Sim] - [Enter = Não]");
            var res = Console.ReadLine();
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("");

            if (res == "0")
            {
                //cria a conexao e fecha a conexao
                using (var connection = new SqlConnection(connectionString))
                {
                    //para evitar o SQL Injection não pode usar interpolação de string
                    //como o var insertSQL = $"INSERT INTO [Category] VALUE ({category.id = Guid.NewGuid()}, {category.title = "Amazon AWS";}";
                    //tem que usar como abaixo:
                    //cria o objeto anonimo de parâmetros
                    var parametrosSQL = new { pessoa.id, pessoa.nome, pessoa.idade, pessoa.cpf, pessoa.email, pessoa.telefone };

                    //executa o comando de INSERT do SQL da variável inserSQL e armazena o retorno na variável rows
                    var rows = connection.Execute(insertSQL, parametrosSQL);

                    Console.WriteLine($"{rows} pessoa foi inserida: {pessoa.nome}");
                }
                Console.WriteLine("");
                Console.WriteLine("Deseja voltar ao menu?");
                Console.WriteLine("[0 = Sim] - [Enter = Não]");
                var voltarMenu = Console.ReadLine();
                if (voltarMenu == "0") { Menu(); }
            }
            else
            {
                Menu();
            }
        }
        public void Read()
        {
            //criada query
            string sql = "SELECT [id], [nome], [idade], [cpf], [email], [telefone] FROM [pessoas]";

            //cria a conexao e fecha a conexao
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                //o .OrderBy(p => p.nome) ordena o resultado por nome alfabetico
                var pessoas = connection.Query<TablePessoas>(sql).OrderBy(p => p.nome);
                //pega cada objeto encontrado dentro da lista de objeto Category

                //estilização
                Console.WriteLine("");
                Console.WriteLine(new String('-', 38));
                Console.WriteLine(">>>>>>>>>>>>>  Listagem  <<<<<<<<<<<<<");
                Console.WriteLine(new String('-', 38));

                //mostra o numero da pessoa na lista
                int contador = 1;

                foreach (var objeto in pessoas)
                {
                    //imprime os itens de cada objeto encontrado apontando a propriedade
                    //Console.WriteLine("");
                    Console.WriteLine($"             Pessoa - { contador }");
                    Console.WriteLine("");
                    Console.WriteLine($"ID: { objeto.id } ");
                    Console.WriteLine($"Nome: { objeto.nome } ");
                    Console.WriteLine($"CPF: { objeto.cpf } ");
                    Console.WriteLine($"Nascimento: { objeto.idade.ToString("dd/MM/yyyy") }");
                    Console.WriteLine($"E-mail: { objeto.email } ");
                    Console.WriteLine($"Telefone: { objeto.telefone } ");
                    Console.WriteLine("");
                    Console.WriteLine(new String('-', 38));
                    contador++;
                }
                Console.WriteLine(new String('X', 38));
                Console.WriteLine($"        Pessoas encontradas: { contador - 1 }");
                Console.WriteLine(new String('X', 38));
                Console.WriteLine("");
                Console.WriteLine("Deseja voltar ao menu?");
                Console.WriteLine("[0 = Sim] - [Enter = Não]");
                var voltarMenu = Console.ReadLine();
                if (voltarMenu == "0") { Menu(); }
            }
        }
        public void ReadOne()
        {
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("");
            Console.WriteLine("Digite o CPF (somente nº): ");
            var CPF = Console.ReadLine();

            //cria a query selecionando apenas o primeiro da lista TOP (1)
            var readOneQuery = "SELECT TOP 1 * FROM [pessoas] WHERE [cpf] = @cpf";

            //cria os parâmetros para a query
            var parametrosSQL = new { cpf = CPF };

            //estilização
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine(">>>>>>>>>>>>>  Listagem  <<<<<<<<<<<<<");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine($"             Pessoa - 1");
            Console.WriteLine("");

            //cria a conexao e fecha a conexao
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                var readOne = connection.QueryFirstOrDefault<TablePessoas>(readOneQuery, parametrosSQL);

                //dados da pessoa
                Console.WriteLine($"ID: {readOne.id} ");
                Console.WriteLine($"Nome: {readOne.nome} ");
                Console.WriteLine($"CPF: {readOne.cpf} ");
                Console.WriteLine($"Nascimento: {readOne.idade.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"E-mail: {readOne.email} ");
                Console.WriteLine($"Telefone: {readOne.telefone} ");
            }

            //estilização
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine(new String('X', 38));
            Console.WriteLine($"        Pessoas encontradas: 1");
            Console.WriteLine(new String('X', 38));
            Console.WriteLine("");
            Console.WriteLine("Deseja voltar ao menu?");
            Console.WriteLine("[0 = Sim] - [Enter = Não]");
            var voltarMenu = Console.ReadLine();
            if (voltarMenu == "0") { Menu(); }
        }
        public void Update()
        {
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("");
            Console.WriteLine("Digite o CPF (somente nº): ");
            var CPF = Console.ReadLine();

            //cria os parâmetros para a query leitura
            var parametrosSQL = new { cpf = CPF };
            //mostrara  pessoa que vai ser excluida
            var readOneQuery = "SELECT TOP 1 * FROM [pessoas] WHERE [cpf] = @cpf";

            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("Quais dados deseja atualizar?");
            Console.WriteLine("");
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                var readOne = connection.QueryFirstOrDefault<TablePessoas>(readOneQuery, parametrosSQL);

                //dados da pessoa
                Console.WriteLine($"ID: {readOne.id} ");
                Console.WriteLine($"[ 1 ] Nome: {readOne.nome} ");
                Console.WriteLine($"[ 2 ] CPF: {readOne.cpf} ");
                Console.WriteLine($"[ 3 ] Nascimento: {readOne.idade.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"[ 4 ] E-mail: {readOne.email} ");
                Console.WriteLine($"[ 5 ] Telefone: {readOne.telefone} ");
            }
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("Digite o nº do dado para alterar");
            Console.WriteLine("ou [ 0 ] para SAIR: ");
            var res = Console.ReadLine();

            //estilização
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));

            //parâmetro e comando SQL
            string sqlUpdate = "";
            object parametrosUpdate = null;

            switch (res)
            {
                case "0": Menu(); break;
                case "1": sqlUpdate = $"UPDATE [pessoas] SET [nome] = @nome WHERE [cpf] = @cpf";
                    Console.WriteLine("Digite o NOVO NOME abaixo: ");
                    var resNome = Console.ReadLine();
                    parametrosUpdate = new { nome = resNome, cpf = CPF };
                    break;                
                case "2": sqlUpdate = $"UPDATE [pessoas] SET [cpf] = @cpf WHERE [cpf] = @novoCpf";
                    Console.WriteLine("Digite o NOVO CPF abaixo: ");
                    var resCPF = Console.ReadLine();
                    parametrosUpdate = new { cpf = resCPF, novocpf = parametrosSQL.cpf };
                    break;
                case "3":
                    sqlUpdate = $"UPDATE [pessoas] SET [idade] = @idade WHERE [cpf] = @cpf";
                    Console.WriteLine("Digite a NOVA DATA abaixo [dd/mm/aaaa]: ");
                    var resNascimento = Console.ReadLine();
                    parametrosUpdate = new { idade = resNascimento, cpf = CPF };
                    break;
                case "4":
                    sqlUpdate = $"UPDATE [pessoas] SET [email] = @email WHERE [cpf] = @cpf";
                    Console.WriteLine("Digite o NOVO E-MAIL abaixo: ");
                    var resEmail = Console.ReadLine();
                    parametrosUpdate = new { email = resEmail, cpf = CPF };
                    break;
                case "5":
                    sqlUpdate = $"UPDATE [pessoas] SET [telefone] = @telefone WHERE [cpf] = @cpf";
                    Console.WriteLine("Digite o NOVO TELEFONE abaixo: ");
                    var resTelefone = Console.ReadLine();
                    parametrosUpdate = new { telefone = resTelefone, cpf = CPF };
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção invalida! Tente novamente...");
                    Thread.Sleep(2000);
                    Menu();
                    break;
            }

            //cria a conexao e fecha a conexao
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                var rows = connection.Execute(sqlUpdate, parametrosUpdate);
                Console.WriteLine("");
                Console.WriteLine($"{rows} registro ATUALIZADO com sucesso!");
            }
            
            //estilização e volta ao menu
            Console.WriteLine("");
            Console.WriteLine("Deseja voltar ao menu?");
            Console.WriteLine("[0 = Sim] - [Enter = Não]");
            var voltarMenu = Console.ReadLine();
            if (voltarMenu == "0") { Menu(); }
        }
        public void Delete()
        {
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("");
            Console.WriteLine("Digite o CPF (somente nº): ");
            var CPF = Console.ReadLine();

            //cria os parâmetros para a query
            var parametrosSQL = new { cpf = CPF };
            //mostrara  pessoa que vai ser excluida
            var readOneQuery = "SELECT TOP 1 * FROM [pessoas] WHERE [cpf] = @cpf";

            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("Deseja excluir a pessoa abaixo?");
            Console.WriteLine("");
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                var readOne = connection.QueryFirstOrDefault<TablePessoas>(readOneQuery, parametrosSQL);

                //dados da pessoa
                Console.WriteLine($"ID: {readOne.id} ");
                Console.WriteLine($"Nome: {readOne.nome} ");
                Console.WriteLine($"CPF: {readOne.cpf} ");
                Console.WriteLine($"Nascimento: {readOne.idade.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"E-mail: {readOne.email} ");
                Console.WriteLine($"Telefone: {readOne.telefone} ");
            }
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("Tem certeza?");
            Console.WriteLine("[0 = Sim] - [Enter = Não]");
            var res = Console.ReadLine();
            
            //estilização
            Console.WriteLine("");
            Console.WriteLine(new String('-', 38));

            if (res == "0")
            {
                //cria a query selecionando apenas o primeiro da lista TOP (1) para ser apagado
                var deleteQuery = "DELETE [pessoas] WHERE [cpf] = @cpf";

                //cria a conexao e fecha a conexao
                using (var connection = new SqlConnection(connectionString))
                {
                    //cria a query na conexao, aponta pro objeto Category
                    var rows = connection.Execute(deleteQuery, parametrosSQL);
                    Console.WriteLine($"{rows} registro excluído com sucesso!");

                }
                Console.WriteLine("");
                Console.WriteLine("Deseja voltar ao menu?");
                Console.WriteLine("[0 = Sim] - [Enter = Não]");
                var voltarMenu = Console.ReadLine();
                if (voltarMenu == "0") { Menu(); }
            }
            else
            {
                Menu();
            }
        }
    }
}
