//using System;

namespace Calculadora
{
    class Program
    {

        static void Main(string[] args)
        {

            Menu();

        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Multiplicar");
            Console.WriteLine("3 - Dividir");
            Console.WriteLine("4 - Subtrair");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("-----------------");
            int valor = int.Parse(Console.ReadLine());

            switch (valor)
            {
                case 1:
                    Soma();
                    break;
                case 2:
                    Multiplicacao();
                    break;
                case 3:
                    Divisao();
                    break;
                case 4:
                    Subtracao();
                    break;
                case 5:
                    //Serve para sair do programa
                    System.Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }


        }
        static void Soma()
        {
            Console.Clear();

            Console.WriteLine("Primeiro Valor: ");
            //passando a string para float
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor: ");
            //passando a string para float
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 + v2;

            Console.WriteLine($"O resultado da SOMA é {resultado}!!");

            Console.ReadKey();

            Menu();
        }
        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro Valor: ");
            //passando a string para float
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor: ");
            //passando a string para float
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 - v2;

            Console.WriteLine($"O resultado da SUBTRAÇÃO é {resultado}!!");

            Console.ReadKey();

            Menu();
        }
        static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 / v2;

            Console.WriteLine($"O valor da DIVISÃO é {resultado}!!!");

            Console.ReadKey();

            Menu();
        }
        static void Multiplicacao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 * v2;

            Console.WriteLine($"O valor da MULTIPLICAÇÃO é {resultado}!!!");

            Console.ReadKey();

            Menu();
        }

    }
}