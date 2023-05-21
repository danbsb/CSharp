using basicCRUD.model;
using System;

namespace basicCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine(new String('-', 38));
            Console.WriteLine(">>  Sistema de Cadastro de Pessoas  <<");
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("");
            Console.WriteLine("[ 0 ] - Inserir pessoa?");
            Console.WriteLine("[ 1 ] - Ver todos os cadastros?");
            Console.WriteLine("[ 2 ] - Atualizar cadastro?");
            Console.WriteLine("[ 3 ] - Deletar pessoa?");            
            Console.WriteLine("[ 4 ] - Procurar pessoa?");
            Console.WriteLine("");
            Console.WriteLine("Insira o valor e ENTER: ");
            var valor = Console.ReadLine();
            
            //inicia o CRUD
            var crud = new DBCRUD();

            switch (valor)
            {
                case "0": crud.Create(); break;
                case "1": crud.Read(); break;
                case "2": crud.Update(); break;
                case "3": crud.Delete(); break;
                case "4": crud.ReadOne(); break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção invalida! Tente novamente...");
                    Thread.Sleep(2000);
                    Menu();
                    break;
            }
        }
    }
}