namespace InstaDev.Interface
{
    public interface IComentario
    {
        void CriarComentario(Comentar e);
        List<Comentar> ListarComentario();
        void EditarComentario(Comentar e);
        void ExcluirComentario(int comentario);
    }
}