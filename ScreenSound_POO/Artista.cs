class Artista
{
    public string Nome { get; set; }
    private List<Album> albums = new List<Album>();


    public Artista(string nome)
    {
        Nome = nome;
    }

    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public int QuantAlbums()
    {
        return albums.Count;
    }

    public List<Album> ExibirAlbums()
    {
        return albums;
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do {Nome}");
        foreach (Album album in albums) 
        { 
            Console.WriteLine($"Album: {album.Titulo}");
        }
    }
}