class Album
{
    public string Titulo { get; set; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    private List<Musica> musicas = new List<Musica>();

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
        Console.WriteLine($"Lista de música do Albúm: {Titulo}\n");
        foreach (Musica musica in musicas)
        {
            Console.WriteLine(musica.DescricaoResumida);
        }
    }
}