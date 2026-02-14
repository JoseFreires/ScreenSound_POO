class Album
{
    public string Titulo { get; set; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    private List<Musica> musicas = new List<Musica>();
    public int QuantMusicas => musicas.Count;

    public Album(string titulo)
    {
        Titulo = titulo;
    }

    public void AddMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirListaMusicas()
    {
        Console.WriteLine($"Lista de música do Album: {Titulo}\n");
        foreach (Musica musica in musicas)
        {
            Console.WriteLine(musica.Nome);
        }
    }
}