using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interfaces
{
    public interface IUsuario
    {
        //CRUD
        void Create(Usuario a);

        List<Usuario> ReadAll();

        void Update(Usuario a);

        void Deletar(int id);
    }
}