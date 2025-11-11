using System.Text.RegularExpressions;

namespace GerenciadorDeAgenda;

internal class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} - Nome: {Nome}, Telefone: {Telefone}";
    }

}
