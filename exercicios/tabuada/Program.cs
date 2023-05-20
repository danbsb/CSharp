class Program
{
    static void Main(string[] args)
    {
        Valor();
    }
    static void Valor()
    {
        Console.Clear();
        Console.WriteLine("Quer ver a tabuada de qual valor? ");
        var valor = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("---------------------");
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine($"{valor} X {i} = {valor * i}");
        }
        Console.WriteLine("---------------------");

        Console.ReadLine();
    }
}