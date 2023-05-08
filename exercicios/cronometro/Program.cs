class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("S = Segundos => 10s = 10 segundos");
        Console.WriteLine("M = Minutos => 1m = 1 minuto");
        Console.WriteLine("0 = Sair");
        Console.WriteLine("Quanto tempo deseja contar?");

        //pega a entrada e transforma pra minusculo
        string entrada = Console.ReadLine().ToLower();

        //pode pegar usando também o "char tipo = char.Parse(entrada.Substring(entrada.Length -1, 1))"
        char tipo = entrada[entrada.Length - 1];

        //pega o 'valor' da string e transforma em int
        int time = int.Parse(entrada.Substring(0, entrada.Length - 1));

        if (tipo == 's')
        {
            Start(time);
        }
        else if (tipo == 'm')
        {
            int minuto = time * 60;
            Start(minuto);
        }
        else
        {
            System.Environment.Exit(0);
        }

        Menu();

        //saber o tipo de dados da variável
        //Console.WriteLine(valor.GetType().Name);

    }
    static void Start(int time)
    {
        int currentTime = 0;

        Console.WriteLine("Ready....!!");
        Thread.Sleep(1000);
        Console.WriteLine("Set....!!");
        Thread.Sleep(1000);
        Console.WriteLine("GO....!!");
        Thread.Sleep(2500);

        while (currentTime != time)
        {
            Console.Clear();
            currentTime++;
            Console.WriteLine(currentTime);
            //faz o programa demorar 1 segundo para executar a proxima tarefa
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Cronometro Finalizado!!");
        Thread.Sleep(2500);
    }
}