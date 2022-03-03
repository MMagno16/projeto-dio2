using System;

namespace PROJETODIO2;

class Program
{

    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3":
                    AtualizarSeries();
                    break;
                case "4":
                    ExcluirSeries();
                    break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();  
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }
    Console.WriteLine("Obrigado por utilizar nossos serviços.");
    Console.ReadLine();
}
private static void ExcluirSeries()
{
    Console.Write("Digite o id da série:");
    int indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Exclui(indiceSerie);
}

private static void VisualizarSeries()
{
    Console.Write("Digite o id da série:");
    int indiceSerie = int.Parse(Console.ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);

    Console.WriteLine(serie);
}

private static async void AtualizarSeries()
{
    Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }
    Console.Write("Digite o gÊnero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.Write("Digite o Título da Série: ");
    int entradaTitulo = Console.ReadLine();

    Console.Write("Digite o Ano do Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.Write("Digite a Descrição da Série: ");
    int entradaDescricao = Console.ReadLine();

    Serie atualizaSerie = new Serie(Id : indiceSerie(),
                                genero: (Genero)entradaGenero,
                                Titulo: entradaTitulo,
                                Ano: entradaAno,
                                Descricao: entradaDescricao);

    repositorio.Atualiza(indiceSerie, atualizaSerie);
}
private static void ListarSeries()
{
    Console.WriteLine("Listar séries");
    var lista = repositorio.Lista();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhuma série cadastrada");
        return;
    }

    foreach (var serie in lista)
    {
        var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}; - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
    }
}

private static async void InserirSeries()
{
    Console.WriteLine("Inserir nova série");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
    }
    Console.Write("Digite o gÊnero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.Write("Digite o Título da Série: ");
    int entradaTitulo = Console.ReadLine();

    Console.Write("Digite o Ano do Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.Write("Digite a Descrição da Série: ");
    int entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(Id : repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                Titulo: entradaTitulo,
                                Ano: entradaAno,
                                Descricao: entradaDescricao);

    repositorio.Insere(novaSerie);
}

private static string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("DIO Séries a seu dispor!");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1- Listar séries");
    Console.WriteLine("2- Inserir nova série");
    Console.WriteLine("3- Atualizar série");
    Console.WriteLine("4- Excluir série");
    Console.WriteLine("5- Visualizar série");
    Console.WriteLine("C- Limpar tela");
    Console.WriteLine("X- Sair");

    string ObterOpcaoUsuario = console.ReadLine().ToUpper();
    Console.WriteLine();
    return ObterOpcaoUsuario;


    
}

    public override string ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
