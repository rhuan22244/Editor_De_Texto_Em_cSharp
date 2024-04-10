using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer ?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");

            if (!short.TryParse(Console.ReadLine(), out short option))
            {
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
                return;
            }

            switch (option)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual é o caminho do arquivo ?");
            string path = Console.ReadLine();

            try
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir o arquivo: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-------------");
            string text = "";

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                if (key.Key != ConsoleKey.Escape)
                {
                    text += key.KeyChar;
                }
            } while (key.Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual é o caminho para salvar o arquivo ?");
            var path = Console.ReadLine();

            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }
                Console.WriteLine($"Arquivo {path} salvo com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();
        }
    }
}

