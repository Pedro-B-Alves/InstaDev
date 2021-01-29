using System;

namespace InstaDev.Models
{
    public class InstadevBase
    {
        //Função que cria a pasta CSV e armazena em linhas as informações inseridas pelos forms
        public void CreateFolderAndFile (string _path){
            string folder = _path.Split("/")[0];
            string file = _path.Split("/")[1];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }
            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }

        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(path))
            {
                string linha;
                while((linha = file.ReadLine())!= null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void RewriteCSV(string _path, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(_path))
            {
                foreach(var item in linhas)
                {
                    output.Write(item + '\n');
                }
            }
        }
    }
}
