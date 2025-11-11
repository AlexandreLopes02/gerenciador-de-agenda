namespace GerenciadorDeAgenda;

internal class Program
{
    private static void Main(string[] args)
    {
        GerenciadorAgenda gerenciador = new GerenciadorAgenda();
        int opcao = 0;

        while (opcao != 6)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("          GERENCIADOR DE AGENDA");
            Console.WriteLine("========================================");
            Console.ResetColor();

            Console.WriteLine("1.  Adicionar Contato");
            Console.WriteLine("2.  Listar Contatos");
            Console.WriteLine("3.  Editar Contato");
            Console.WriteLine("4.  Remover Contato");
            Console.WriteLine("5.  Buscar Contato");
            Console.WriteLine("6.  Sair");
            Console.WriteLine("----------------------------------------");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = 0;

            Console.Clear();
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
                    Console.WriteLine("Saindo... Até logo!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ResetColor();
                    break;
            }

            if (opcao != 6)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}