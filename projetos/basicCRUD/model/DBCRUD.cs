using basicCrud;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicCRUD.model
{
    class DBCRUD : Program
    {
        //cria a string de conexao
        private const string connectionString = "Server = localhost, 1401; Database = crudPessoas; User ID = sa; Password = D@n031193; TrustServerCertificate=True";

        public void Read()
        {
            //cria a conexao e fecha a conexao
            using (var connection = new SqlConnection(connectionString))
            {
                //cria a query na conexao, aponta pro objeto Category
                var pessoas = connection.Query<TablePessoas>("SELECT [id], [nome], [idade], [cpf], [email], [telefone] FROM [pessoas]");
                //pega cada objeto encontrado dentro da lista de objeto Category

                //estilização
                Console.WriteLine("");
                Console.WriteLine(new String('-', 38));
                Console.WriteLine(" >>>>>>  Pessoas  Cadastradas  <<<<<<");
                Console.WriteLine(new String('-', 38));

                //mostra o numero da pessoa na lista
                int? contador = 1;

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
                Console.WriteLine($"---     Pessoas cadastradas: { contador - 1 }    ---");
                Console.WriteLine(new String('X', 38));
                Console.WriteLine("");
                Console.WriteLine("Deseja voltar ao menu?");
                Console.WriteLine("[0 = Sim] - [Enter = Não]");
                var voltarMenu = Console.ReadLine();
                if (voltarMenu == "0") { Menu(); }
            }
        }
    }
}
