using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario
    {
        public string PATH = "Database/Usuario.csv";

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

            // Using -> responsável por abrir e fechar o arquivo automaticamente
            // StreaamReader -> Ler dados de um arquivo
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                // Percorrer as linhas com um laço while
                while( (linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }
    }
}