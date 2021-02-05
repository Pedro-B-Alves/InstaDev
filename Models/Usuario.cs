<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Models
{
    public class Usuario : InstaDevBase , Interfaces.IUsuario
    {
        //Classes
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataDeNascimento { get; set; }
        
        public int Seguidos { get; set; }
        
        public string Email { get; set; }

        public string Username { get; set; }

        public string senha { get; set; }

        private const string PATH = "Database/Usuario.csv";

        public Usuario(){
            CreateFolderAndFile(PATH);
        }

        public string Preparar(Usuario a)
        {
            return $"{a.IdUsuario};{a.Nome};{a.Foto};{a.DataDeNascimento};{a.Seguidos};{a.Email};{a.Username};{a.senha}";
        }

        //CRUD

        public void Create(Usuario a)
        {
            string [] linhas = { Preparar(a) };

            File.AppendAllLines(PATH, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            RewriteCSV(PATH, linhas);
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> usuario = new List<Usuario>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario novoUsuario = new Usuario();

                novoUsuario.IdUsuario        = int.Parse( linha[0] );
                novoUsuario.Nome             = linha[1];
                novoUsuario.Foto             = linha[2];
                novoUsuario.DataDeNascimento = DateTime.Parse(linha[3] );
                novoUsuario.Seguidos         = int.Parse(linha[4]);
                novoUsuario.Email            = linha[5];
                novoUsuario.Username         = linha[6];
                novoUsuario.senha            = linha[7];

                usuario.Add(novoUsuario);
            }

            return usuario;
        }
        

        public void Update(Usuario a)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == a.IdUsuario.ToString());

            linhas.Add( Preparar(a) );

            RewriteCSV(PATH, linhas);
        }
        // CRUD fim

        public Usuario Mostrar(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            var usuario = linhas.Find(x => x.Split(";")[0] == IdUsuario.ToString());

            string[] mostrarDados = usuario.Split(";");
            
            Usuario usuarioDados = new Usuario();

            usuarioDados.IdUsuario        = int.Parse( mostrarDados[0] );
            usuarioDados.Nome             = mostrarDados[1];
            usuarioDados.Foto             = mostrarDados[2];
            usuarioDados.DataDeNascimento = DateTime.Parse(mostrarDados[3] );
            usuarioDados.Seguidos         = int.Parse(mostrarDados[4]);
            usuarioDados.Email            = mostrarDados[5];
            usuarioDados.Username         = mostrarDados[6];
            usuarioDados.senha            = mostrarDados[7];

            return usuarioDados;
        }


=======
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario : InstaDevBase
    {
        public string PATH = "Database/Usuario.csv";
>>>>>>> develop
    }
}