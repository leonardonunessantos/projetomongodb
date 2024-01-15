class Program
{
    static void Main()
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "ToDoListDatabase";

        var contentRepository = new ContentRepository(connectionString, databaseName);

        while (true)
        {
            Console.WriteLine("Escolha uma operação:");
            Console.WriteLine("1. Criar nota");
            Console.WriteLine("2. Alterar nota");
            Console.WriteLine("3. Deletar nota");
            Console.WriteLine("4. Visualizar notas");
            Console.WriteLine("0. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite o conteúdo da nota:");
                    string description = Console.ReadLine();
                    contentRepository.CreateContent(new Content { Description = description, Date = DateTime.Now });
                    break;

                case "2":
                    var contents = contentRepository.ReadContents();
                    Console.WriteLine("Escolha o ID da nota que deseja alterar:");
                    foreach (var conteudo in contents)
                    {
                        Console.WriteLine($"ID: {conteudo.Id}, Conteúdo: {conteudo.Description}, Data de criação: {conteudo.Date}");
                    }

                    if (contents.Any())
                    {
                        Console.Write("Digite o ID: ");
                        int idAlterar;
                        if (int.TryParse(Console.ReadLine(), out idAlterar))
                        {
                            Console.Write("Digite o novo conteúdo: ");
                            string novoConteudo = Console.ReadLine();
                            contentRepository.UpdateContent(idAlterar, novoConteudo);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há notas para alterar.");
                    }
                    break;

                case "3":
                    var conteudosDeletar = contentRepository.ReadContents();
                    Console.WriteLine("Escolha o ID da nota que deseja deletar:");
                    foreach (var conteudo in conteudosDeletar)
                    {
                        Console.WriteLine($"ID: {conteudo.Id}, Conteúdo: {conteudo.Description}, Data de criação: {conteudo.Date}");
                    }

                    if (conteudosDeletar.Any())
                    {
                        Console.Write("Digite o ID: ");
                        int idDeletar;
                        if (int.TryParse(Console.ReadLine(), out idDeletar))
                        {
                            contentRepository.DeleteContent(idDeletar);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há notas para deletar.");
                    }
                    break;

                case "4":
                    var todasNotas = contentRepository.ReadContents();
                    Console.WriteLine("Notas disponíveis:");
                    foreach (var nota in todasNotas)
                    {
                        Console.WriteLine($"ID: {nota.Id}, Conteúdo: {nota.Description}, Data de Criação: {nota.Date}");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
