class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!!");
        Console.WriteLine(EProduto.Produto);
        Console.WriteLine((int)EProduto.Produto);
        Console.WriteLine(EProduto.Serviço);
        Console.WriteLine((int)EProduto.Serviço);
        Console.ReadLine();
    }
    enum EProduto
    {
        Produto = 0,
        Serviço = 1
    }
}