namespace InstaDev.Interfaces
{
    public class IUsuario
    {
        //CRUD

        void Create(Usiario a);

        List<Usuario> readAll();

        void Update(Usuario a);

        void Deletar(int id);
    }
}