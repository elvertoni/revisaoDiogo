namespace API.Models;
public class Livro
{
    public Livro() => CriadoEm = DateTime.Now;

    public int LivroId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
    public Genero? Genero { get; set; }
    public int GeneroId { get; set; }
}
