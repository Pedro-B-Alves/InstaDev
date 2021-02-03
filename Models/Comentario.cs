using InstaDev.Interface;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Comentario : IComentario 
    {
        public int IdComentario { get; set; }
        public string Mensagem { get; set; }
        public int Usuario { get; set; }
        public int IdPublicacao { get; set; }
        
        private const string PATH = "Database/Comentarios.csv";

        public Comentario()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Comentario e)
        {
            return $"{e.IdPublicacao};{e.IdComentario};{e.Usuario};{e.Mensagem}";
        }

    //CRUD
        public void CriarComentario (Comentario e)
        {
            string [] linhas = {Prepare(e)};
            File.AppendAllLines(PATH, linhas);
        }

        public void DeletarComentario(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            RewriteCSV(PATH, linhas);
        }

        public List<Comentario> LerComentario()
        {
            List<Comentario> Comentar = new List<Comentario>();
            string [] linhas = File.ReadAllLines(PATH);
            foreach(string item in linhas)
            {
                string[] linha = item.Split(";");

                Comentar novoComent = new Comentar();
                novoComent.IdPublicacao = int.Parse(linha[0]);
                novoComent.IdComentario = int.Parse(linha[1]);
                novoComent.Usuario = linha [2];
                novoComent.Mensagem = linha [3];


                Comentarios.Add(novoComent);
            }
            return Comentarios;
        }

        public void EditarComentario(Comentario e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdComentario.ToString());
            linhas.Add(Prepare (e));

            RewriteCSV(PATH, linhas);
        }
    }
}