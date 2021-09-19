using System;

namespace Projeto.CulturaPop
{
    class Program
    {

        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)

        {
            string primeiraOpcao = ObterPrimeiraOpcao();
            {
                while (primeiraOpcao.ToUpper() != "X")
                {
                    switch (primeiraOpcao)
                    {
                        case "1":
                            Animes();
                            break;
                        case "2":
                            Séries();
                            break;
                        case "3":
                            Filmes();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    primeiraOpcao = ObterPrimeiraOpcao();

                }
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
                
            }
        }

        private static string ObterPrimeiraOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao Cultura Pop! ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Animes");
            Console.WriteLine("2- Séries");
            Console.WriteLine("3- Filmes");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair ");
            Console.WriteLine();

            string primeiraOpcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return primeiraOpcao;
        }

        private static void Animes()
        {


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Aperte Enter para voltar ao menu inicial ");
            Console.ReadLine();
            
        }
        private static void ExcluirAnime()
        {
            Console.Write("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceAnime);
        }
        private static void VisualizarAnime()
        {
            Console.Write("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = repositorio.RetornaPorId(indiceAnime);

            Console.WriteLine(anime);
        }
        private static void AtualizarAnime()
        {
            Console.Write("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do anime: ");
            string entradaDescricao = Console.ReadLine();


            Anime atualizaAnime = new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);


            repositorio.Atualiza(indiceAnime, atualizaAnime);
        }

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar animes");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrado.");
                return;
            }

            foreach (var anime in lista)
            {
                var excluido = anime.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2} ", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo anime");


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoAnime);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar animes");
            Console.WriteLine("2- Inserir novo anime");
            Console.WriteLine("3- Atualizar anime");
            Console.WriteLine("4- Excluir anime");
            Console.WriteLine("5- Visualizar anime");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Voltar menu inicial");
            Console.WriteLine();

            string opacaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opacaoUsuario;
        }

        private static void Séries()
        {
            {
                string opcaoUsuario2 = ObterOpcaoUsuario2();

                while (opcaoUsuario2.ToUpper() != "X")
                {
                    switch (opcaoUsuario2)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario2 = ObterOpcaoUsuario2();
                }

                Console.WriteLine("Aperte Enter para voltar ao menu inicial.");
                Console.ReadLine();

            }
            static void ExcluirSerie()
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorioSerie.Exclui(indiceSerie);
            }

            static void VisualizarSerie()
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorioSerie.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);
            }
            static void AtualizarSerie()
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());


                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
            }

            static void ListarSeries()
            {
                Console.WriteLine("Listar séries");
                var lista = repositorioSerie.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();

                    Console.WriteLine("#ID {0}: - {1} {2} ", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }
            }

            static void InserirSerie()
            {
                Console.WriteLine("Inserir nova série");


                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorioSerie.Insere(novaSerie);
            }

            static string ObterOpcaoUsuario2()
            {
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine("C- Limpar tela");
                Console.WriteLine("X- Voltar menu inicial");
                Console.WriteLine();

                string opacaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opacaoUsuario;

            }

        }

        private static void Filmes()
        {
            {
                string opcaoUsuario3 = ObterOpcaoUsuario3();

                while (opcaoUsuario3.ToUpper() != "X")
                {
                    switch (opcaoUsuario3)
                    {
                        case "1":
                            ListarFilme();
                            break;
                        case "2":
                            InserirFilme();
                            break;
                        case "3":
                            AtualizarFilme();
                            break;
                        case "4":
                            ExcluirFilme();
                            break;
                        case "5":
                            VisualizarFilme();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario3 = ObterOpcaoUsuario3();
                }

                Console.WriteLine("Aperte Enter para voltar ao menu inicial.");
                Console.ReadLine();

            }

            static void ExcluirFilme()
            {
                Console.Write("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                repositorioFilme.Exclui(indiceFilme);
            }

            static void VisualizarFilme()
            {
                Console.Write("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                var filme = repositorioFilme.RetornaPorId(indiceFilme);

                Console.WriteLine(filme);
            }
            static void AtualizarFilme()
            {
                Console.Write("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());


                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título do filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de início do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
            }

            static void ListarFilme()
            {
                Console.WriteLine("Listar filmes");
                var lista = repositorioFilme.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhum filme cadastrado.");
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();

                    Console.WriteLine("#ID {0}: - {1} {2} ", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }
            }

            static void InserirFilme()
            {
                Console.WriteLine("Inserir novo Filme");


                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título do filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de início do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorioFilme.Insere(novoFilme);
            }

            static string ObterOpcaoUsuario3()
            {
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1- Listar filmes");
                Console.WriteLine("2- Inserir novo filme");
                Console.WriteLine("3- Atualizar filme");
                Console.WriteLine("4- Excluir filme");
                Console.WriteLine("5- Visualizar filme");
                Console.WriteLine("C- Limpar tela");
                Console.WriteLine("X- Voltar menu incial");
                Console.WriteLine();

                string opacaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opacaoUsuario;

            }
        }
        
    }

}






 
