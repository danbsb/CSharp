class Program
{
    static void Main(string[] args)
    {
        Notas();
    }
    static void Notas()
    {
        Console.Clear();
        Console.WriteLine("Digite a Primeira Nota: ");
        string n1 = Console.ReadLine();
        Console.WriteLine("Digite a Segunda Nota: ");
        string n2 = Console.ReadLine();

        Media(n1, n2);
    }
    static void Media(string nota1, string nota2)
    {
        double primeiraNota = Convert.ToDouble(nota1);
        double segundaNota = Convert.ToDouble(nota2);

        var media = (primeiraNota + segundaNota) / 2;

        Situacao(media);

    }
    static void Situacao(double media)
    {
        var resultado = media >= 7 ? "Aprovado!" : "Reprovado!";
        Console.WriteLine(resultado);
        //da pra fazer direto como abaixo:
        //Console.WriteLine(media >= 7 ? "Aprovado!" : "Reprovado!");

        //Criado pro console não fechar rápido
        Console.ReadLine();
    }
}