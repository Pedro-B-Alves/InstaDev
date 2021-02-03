using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interface
{
    public interface IComentario
    {
        void Create (Comentario e);
        List<Comentario> ReadAll();
        void Update (Comentario e);
        void Delete (int IdComentario);
    }
}