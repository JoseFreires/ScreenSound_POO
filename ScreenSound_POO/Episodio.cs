class Episodio
{
    public Episodio(int duracao, int ordem, string resumo, string titulo)
    {
        Duracao = duracao;
        Ordem = ordem;
        Resumo = resumo;
        Titulo = titulo;
    }

    public int Duracao { get; set; }
    public int Ordem { get; set; }
    public string Resumo { get; set; }
    public string Titulo { get; set; }
    private List<string> convidados = new List<string>();

    public void AddConvidados(string convidado)
    {
        convidados.Add(convidado);
    }

    public void ExibirInfoEp()
    {
        Console.WriteLine($"{Ordem} - {Titulo} - '{Resumo}' - Duração: {Duracao}");
    }
}