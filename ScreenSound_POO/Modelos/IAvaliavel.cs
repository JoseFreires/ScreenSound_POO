using ScreenSound.Modelos;

namespace ScreenSound_POO.Modelos;

internal interface IAvaliavel
{
    void AdicionarNota(Avaliacao nota);
    double Media { get; }
}
