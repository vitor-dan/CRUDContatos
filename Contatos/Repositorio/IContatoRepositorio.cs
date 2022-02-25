using Contatos.Models;
using System.Collections.Generic;

namespace Contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel listarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
        bool ExisteUsuario(ContatoModel contato);
    }
}
