using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interface
{
    public interface IComentario
    {
        void CriarComentario (Comentario e);
        List<Comentario> LerComentario();
        void EditarComentario (Comentario e);
        void DeletarComentario (int IdComentario);
    }
}