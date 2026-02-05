class Podcast
{
    public Podcast(string host, string nome)
    {
        Host = host;
        Nome = nome;
    }

    public string Host { get; set; }
    public string Nome { get; set; }
    public int TotalEps { get; set; }

    private List<Episodio> Episodios = new List<Episodio>();


    public void AddEpisodio(Episodio episodio)
    {
        Episodios.Add(episodio);
        TotalEps = +1;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Informações sobre o podcast: {Nome}");
        Console.WriteLine($"Quantidade de episódios: {TotalEps}");
        Console.WriteLine($"O seu host é: {Host}");
        Console.WriteLine($"Segue a lista de episódios lançados atualmente:");

        if(Episodios.Count > 0)
        {
            foreach (Episodio ep in Episodios.OrderBy(e => e.Ordem))
            {
                ep.ExibirInfoEp();
            }
        }
        else
        {
            Console.WriteLine("Nenhum episódio foi lançado ainda");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("----------------------------------");
    }

    public void ExibirEpsPodcast()
    {
        foreach(Episodio ep in Episodios)
        {
            ep.ExibirInfoEp();
        }
    }
}