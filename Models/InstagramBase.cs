namespace InstaDev.Models
{
    public class InstagramBase
    {
        public void CreateFolderAndFile(string _path)
        {
            string folder = _path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))
            {
                File.Create(_path);
            }
        }
        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                while ( (linha = file.ReadLine))
                {
                    
                }
            }

        }
    }
}