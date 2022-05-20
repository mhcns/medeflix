using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSeries = new SerieRepositorio();
        static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        //Listagem
        private static void Listar()
        {
            System.Console.WriteLine("Listar:");
            System.Console.WriteLine("1- Séries");
            System.Console.WriteLine("2- Filmes");
            System.Console.WriteLine("3- Tudo");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    ListarSeries();
                    break;
                case 2:
                    ListarFilmes();
                    break;
                default:
                    ListarTudo();
                    break;
            }

        }
        private static void ListarSeries()
        {
            var lista = repositorioSeries.Lista();
            System.Console.WriteLine();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Não há séries cadastradas.");
                return;
            }
            else
            {
                foreach (var serie in lista)
                {
                    System.Console.WriteLine("#ID {0}: - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "*Excluído*" : "");
                }
            }
        }
        private static void ListarFilmes()
        {
            var lista = repositorioFilmes.Lista();
            System.Console.WriteLine();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Não há filmes cadastrados.");
                return;
            }
            else
            {
                foreach (var filme in lista)
                {
                    System.Console.WriteLine("#ID {0}: - {1}  {2}", filme.retornaId(), filme.retornaTitulo(), filme.retornaExcluido() ? "*Excluído*" : "");
                }
            }
        }
        private static void ListarTudo()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Séries:");
            ListarSeries();

            System.Console.WriteLine("---------------------------------------");
            System.Console.WriteLine("Filmes:");
            ListarFilmes();
        }
        //Inserção
        private static void Inserir()
        {
            System.Console.WriteLine("Inserir:");
            System.Console.WriteLine("1- Série");
            System.Console.WriteLine("2- Filme");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    InserirSerie();
                    break;
                case 2:
                    InserirFilme();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o número do gênero da série de acordo com a tabela acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Digite o número de episódios: ");
            int entradaEpisodios = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o ano em que a série foi lançada: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Insira a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(repositorioSeries.ProximoId(),
                                    (Genero)entradaGenero,
                                    entradaTitulo,
                                    entradaEpisodios,
                                    entradaDescricao,
                                    entradaAno);
            repositorioSeries.Insere(serie);
        }
        private static void InserirFilme()
        {
            System.Console.WriteLine("Inserir filme");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o número do gênero do filme de acordo com a tabela acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Digite a duração do filme (em minutos): ");
            int entradaDuracao = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o ano em que o filme foi lançado: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Insira a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme filme = new Filme(repositorioSeries.ProximoId(),
                                    (Genero)entradaGenero,
                                    entradaTitulo,
                                    entradaDuracao,
                                    entradaDescricao,
                                    entradaAno);
            repositorioFilmes.Insere(filme);
        }
        //Atualização
        private static void Atualizar()
        {
            System.Console.WriteLine("Atualizar:");
            System.Console.WriteLine("1- Série");
            System.Console.WriteLine("2- Filme");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    AtualizarSerie();
                    break;
                case 2:
                    AtualizarFilme();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Atualizar série");
            var lista = repositorioSeries.Lista();
            System.Console.WriteLine("Digite o ID da série na qual deseja atualizar: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"A série de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                System.Console.WriteLine("Digite o número do gênero da série de acordo com a tabela acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o título da série: ");
                string entradaTitulo = Console.ReadLine();
                System.Console.WriteLine("Digite o número de episódios: ");
                int entradaEpisodios = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o ano em que a série foi lançada: ");
                int entradaAno = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Insira a descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie serie = new Serie(entradaID,
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaEpisodios,
                                        entradaDescricao,
                                        entradaAno);
                repositorioSeries.Atualiza(entradaID, serie);
            }
        }
        private static void AtualizarFilme()
        {
            System.Console.WriteLine("Atualizar filme");
            var lista = repositorioSeries.Lista();
            System.Console.WriteLine("Digite o ID do filme no qual deseja atualizar: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"O filme de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                System.Console.WriteLine("Digite o número do gênero do filme de acordo com a tabela acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o título do filme: ");
                string entradaTitulo = Console.ReadLine();
                System.Console.WriteLine("Digite a duração do filme (em minutos): ");
                int entradaDuracao = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o ano em que o filme foi lançado: ");
                int entradaAno = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Insira a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme filme = new Filme(repositorioSeries.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDuracao,
                                        entradaDescricao,
                                        entradaAno);
                repositorioFilmes.Insere(filme);
            }
        }
        //Exclusão
        private static void Excluir()
        {
            System.Console.WriteLine("Excluir:");
            System.Console.WriteLine("1- Série");
            System.Console.WriteLine("2- Filme");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    ExcluirSerie();
                    break;
                case 2:
                    ExcluirFilme();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Excluir série");
            var lista = repositorioSeries.Lista();
            System.Console.WriteLine("Digite o ID da série à qual deseja excluir: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"A série de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                lista[entradaID].Excluir();
            }
        }
        private static void ExcluirFilme()
        {
            System.Console.WriteLine("Excluir filme");
            var lista = repositorioFilmes.Lista();
            System.Console.WriteLine("Digite o ID do filme ao qual deseja excluir: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"O filme de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                lista[entradaID].Excluir();
            }
        }
        //Listagem por ID
        private static void Visualizar()
        {
            System.Console.WriteLine("Visualizar:");
            System.Console.WriteLine("1- Série");
            System.Console.WriteLine("2- Filme");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    VisualizarSerie();
                    break;
                case 2:
                    VisualizarFilme();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Visualizar série");
            var lista = repositorioSeries.Lista();
            System.Console.WriteLine("Digite o ID da série a ser visualizada: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"A série de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                Serie serie = repositorioSeries.RetornaPorId(entradaID);
                System.Console.WriteLine(serie.ToString());
            }
        }
        private static void VisualizarFilme()
        {
            System.Console.WriteLine("Visualizar filme");
            var lista = repositorioFilmes.Lista();
            System.Console.WriteLine("Digite o ID do filme a ser visualizado: ");
            int entradaID = int.Parse(Console.ReadLine());
            if (lista.Count <= entradaID)
            {
                System.Console.WriteLine($"O filme de ID: {entradaID} não existe.");
                return;
            }
            else
            {
                Filme filme = repositorioFilmes.RetornaPorId(entradaID);
                System.Console.WriteLine(filme.ToString());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries a seu dispor!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar séries/filmes");
            System.Console.WriteLine("2- Inserir série/filme");
            System.Console.WriteLine("3- Atualizar série/filme");
            System.Console.WriteLine("4- Excluir série/filme");
            System.Console.WriteLine("5- Visualizar série/filme");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
