namespace GerenciadorDeAgenda;

internal class Program
{
    private static void Main(string[] args)
    {
        GerenciadorAgenda gerenciador = new GerenciadorAgenda();
        int opcao = 0;

        while (opcao != 6)
        {
            Console.WriteLine("Gerenciador de Agenda");
            Console.WriteLine("1. Adicionar Contato");
            Console.WriteLine("2. Listar Contatos");
            Console.WriteLine("3. Editar Contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Buscar contato");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine() ?? "0");
            switch (opcao)
            {
                case 1:
                    gerenciador.AdicionarContato();
                    break;
                case 2:
                    gerenciador.ListarContatos();
                    break;
                case 3:
                    gerenciador.AtualizarContato();
                    break;
                case 4:
                    gerenciador.RemoverContato();
                    break;
                case 5:
                    gerenciador.BuscarContato();
                    break;
                case 6:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Console.WriteLine();
        }
    }
}