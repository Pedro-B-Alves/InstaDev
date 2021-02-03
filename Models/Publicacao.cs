using System.Collections.Generic;
using System.IO;
using InstaDev.Interfaces;

namespace InstaDev.Models
{
    public class Publicacao : InstaDevBase , IPublicacao
    {
        public int IdPublicacao { get; set; }
        public string Imagem { get; set; }
        public string Legenda { get; set; }
        public int IdUsuario { get; set; }
        public int Likes { get; set; }

        private const string PATH = "Database/Publicacao.csv";
        
        public Publicacao()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.Imagem};{p.Legenda};{p.IdUsuario};{p.Likes}";
        }

        public void CriarPublicacao(Publicacao p)
        {
            // Preparamos um array de string para o método AppendAllLines
            string[] linhas = { Prepare(p) };
            // Acrescentamos a nova linha
            File.AppendAllLines(PATH, linhas);
        }

        public void ExcluirPublicacao(int id)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos as linhas com o código comparado
            // ToString -> converte para texto (string)
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            // Reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }

        // Lista todas as publicações
        public List<Publicacao> ListarPublicacao()
        {
            List<Publicacao> publicacoes = new List<Publicacao>();

            // Lemos todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao novaPublicacao = new Publicacao();
                novaPublicacao.IdPublicacao = int.Parse( linha[0] );
                novaPublicacao.Imagem = linha[1];
                novaPublicacao.Legenda = linha[2];
                novaPublicacao.IdUsuario = int.Parse( linha[3] );
                novaPublicacao.Likes = int.Parse( linha[4] );

                publicacoes.Add(novaPublicacao);
            }

            return publicacoes;
        }

        // Lista todas as publicações que tem o id do usuário
        public List<Publicacao> ListarPublicacao(int id)
        {
            List<Publicacao> publicacoes = new List<Publicacao>();

            // Lemos todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao novaPublicacao = new Publicacao();

                if ( int.Parse(linha[3]) == id )
                {
                    novaPublicacao.IdPublicacao = int.Parse( linha[0] );
                    novaPublicacao.Imagem = linha[1];
                    novaPublicacao.Legenda = linha[2];
                    novaPublicacao.IdUsuario = int.Parse( linha[3] );
                    novaPublicacao.Likes = int.Parse( linha[4] );

                    publicacoes.Add(novaPublicacao);
                }
            }
            return publicacoes;
        }

        public void EditarPublicacao(Publicacao p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos as linhas com o código comparado
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPublicacao.ToString());

            // Adicionamos na lista a publicação alterada
            linhas.Add( Prepare(p) );

            // Reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }

        // Aumenta o número de likes com o id da publicação
        public void Curtir(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");
                Publicacao novaPublicacao = new Publicacao();
                if (int.Parse(linha[0]) == id )
                {
                    novaPublicacao.IdPublicacao = int.Parse( linha[0] );
                    novaPublicacao.Imagem = linha[1];
                    novaPublicacao.Legenda = linha[2];
                    novaPublicacao.IdUsuario = int.Parse( linha[3] );
                    novaPublicacao.Likes = int.Parse( linha[4] ) +1 ;

                    linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
                    linhas.Add( Prepare(novaPublicacao) );
                    RewriteCSV(PATH, linhas);
                }
            }   
        }
    }
}