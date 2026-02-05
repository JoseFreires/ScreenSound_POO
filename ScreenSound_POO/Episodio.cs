class Episodio
{
    public Episodio(int duracao, int ordem, string resumo, string titulo)
    {
        Duracao = duracao;
        Ordem = ordem;
        Resumo = resumo;
        Titulo = titulo;
    }

    public int Duracao { get; }
    public int Ordem { get; }
    public string Resumo { get; }
    public string Titulo { get;}
    private List<string> convidados = new();

    public void AddConvidados(string convidado)
    {
        convidados.Add(convidado);
    }

    public void ExibirInfoEp()
    {
        Console.WriteLine($"{Ordem} - {Titulo} - '{Resumo}' - Duração: {Duracao}");
    }
}