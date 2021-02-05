using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interfaces
{
    public interface IUsuario
    {
<<<<<<< HEAD
=======
        //CRUD
>>>>>>> fe534cf485139a6f4225e68702d68674b9295068
        void Create(Usuario a);

        List<Usuario> ReadAll();

        void Update(Usuario a);

        void Deletar(int id);
    }
}