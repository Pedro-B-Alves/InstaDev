using InstaDev.Interface;
namespace InstaDev.Models
{
    public class Comentario : IComentario 
    {
        public int IdComentario { get; set; }
        public string Mensagem { get; set; }
        public int Usuario { get; set; }
        public int IdPublicacao { get; set; }
        
        private const string PATH = "Database/Equipe.csv";
    }
}