class Musica
{
    // Construtor
    public Musica(string nome, int duracao, int anoLancamento, Genero genero)
    {
        Nome = nome;
        Duracao = duracao;
        AnoLancamento = anoLancamento;
        Genero = genero;
    }

    // Propriedades
    public string Nome { get;}
    public int Duracao { get; }
   
    public bool Disponivel { get; }
    public int AnoLancamento { get; }
    public Genero Genero { get; }


    // Método
    public string DescricaoResumida => $"A música {Nome}.";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Você possui acesso a essa música!");
        } else
        {
            Console.WriteLine("Apenas disponível no plano MasterMusics");
        }
    }


}