using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interfaces
{
    public interface IPublicacao
    {
         // Métodos de CRUD - Contrato
        void CriarPublicacao(Publicacao p);
        List<Publicacao> ListarPublicacao();
        void EditarPublicacao(Publicacao p);
        void ExcluirPublicacao(int id);
        void Curtir(int id);
    }
}