using System.Text.RegularExpressions;

namespace GerenciadorDeAgenda;

internal class GerenciadorAgenda
{
    List<Contato> contatos = new List<Contato>();
    private int proximoId = 1;
    string nomeArquivo = "contatos.json";
    private readonly Regex regexNumero = new Regex(@"^\d{11}$");

    public GerenciadorAgenda()
    {
        CarregarContatos();
        if (contatos.Count > 0)
        {
            proximoId = contatos.Max(c => c.Id) + 1;
        }
    }

    // ------------------------ CRUD ------------------------
    public void AdicionarContato()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.Write("Digite o telefone: ");
        string telefone = Console.ReadLine() ?? "";

        // Validações
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio.\n");
            return;
        }

        if (!regexNumero.IsMatch(telefone))
        {
            Console.WriteLine("Número inválido! Deve conter exatamente 11 dígitos numéricos.\n");
            return;
        }

        if (ExisteNome(nome))
        {
            Console.WriteLine("Já existe um contato com esse nome.\n");
            return;
        }

        if (ExisteNumero(telefone))
        {
            Console.WriteLine("Já existe um contato com esse número.\n");
            return;
        }
        Contato novoContato = new Contato { Id = proximoId++, Nome = nome, Telefone = telefone };
        contatos.Add(novoContato);
        salvarContatos();
        Console.WriteLine("Contato adicionado com sucesso!");
    }

    public void ListarContatos()
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato encontrado");
            return;
        }
        foreach (var contato in contatos)
        {
            Console.WriteLine(contato);

        }
    }

    public void AtualizarContato()
    {
        Console.Write("Digite o ID do contato a ser atualizado: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.\n");
            return;
        }
        Contato? contato = BuscarPorId(id);
        if (contato == null)
        {
            Console.WriteLine("Contato não encontrado.\n");
            return;
        }
        Console.Write("Digite o novo nome (deixe vazio para manter o atual): ");
        string novoNome = Console.ReadLine() ?? "";
        Console.Write("Digite o novo telefone (deixe vazio para manter o atual): ");
        string novoTelefone = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            if (ExisteNome(novoNome) && !novoNome.Equals(contato.Nome, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Já existe um contato com esse nome.\n");
                return;
            }
            contato.Nome = novoNome;
        }
        if (!string.IsNullOrWhiteSpace(novoTelefone))
        {
            if (!regexNumero.IsMatch(novoTelefone))
            {
                Console.WriteLine("Número inválido! Deve conter exatamente 11 dígitos numéricos.\n");
                return;
            }
            if (ExisteNumero(novoTelefone) && !novoTelefone.Equals(contato.Telefone))
            {
                Console.WriteLine("Já existe um contato com esse número.\n");
                return;
            }
            contato.Telefone = novoTelefone;
        }
        salvarContatos();
        Console.WriteLine("Contato atualizado com sucesso!");
    }

    public void RemoverContato()
    {
        Console.Write("Digite o ID do contato a ser removido: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.\n");
            return;
        }
        Contato? contato = BuscarPorId(id);
        if (contato == null)
        {
            Console.WriteLine("Contato não encontrado.\n");
            return;
        }
        contatos.Remove(contato);
        salvarContatos();
        Console.WriteLine("Contato removido com sucesso!");
    }

    public void BuscarContato()
    {
        Console.Write("Digite o nome ou parte do nome para buscar: ");
        string termoBusca = Console.ReadLine() ?? "";
        var resultados = contatos.Where(c => c.Nome.Contains(termoBusca, StringComparison.OrdinalIgnoreCase)).ToList();
        if (resultados.Count == 0)
        {
            Console.WriteLine("Nenhum contato encontrado com esse termo.\n");
            return;
        }
        foreach (var contato in resultados)
        {
            Console.WriteLine(contato);
        }
    }

    // ------------------------ AUXILIARES ------------------------
    private Contato? BuscarPorId(int id)
    {
        return contatos.Find(c => c.Id == id);
    }

    private bool ExisteNome(string nome)
    {
        return contatos.Exists(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    private bool ExisteNumero(string numero)
    {
        return contatos.Exists(c => c.Telefone == numero);
    }

    // ------------------------ PERSISTENCIA DE DADOS ------------------------
    public void salvarContatos()
    {
        string json = System.Text.Json.JsonSerializer.Serialize(contatos);
        File.WriteAllText(nomeArquivo, json);
    }

    public void CarregarContatos()
    {
        if (File.Exists(nomeArquivo))
        {
            string json = File.ReadAllText(nomeArquivo);
            var contatosCarregados = System.Text.Json.JsonSerializer.Deserialize<List<Contato>>(json);
            if (contatosCarregados != null)
            {
                contatos = contatosCarregados;
                if (contatos.Count > 0)
                {
                    proximoId = contatos.Max(c => c.Id) + 1;
                }
            }
        }
    }
}
