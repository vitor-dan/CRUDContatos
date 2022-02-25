using Contatos.Data;
using Contatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel listarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = listarPorId(contato.Id);

            if (contatoDB == null) 
                throw new System.Exception("Houve um erro na atualização do contato!");
           
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;


            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = listarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro ao deletar o contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public bool ExisteUsuario(ContatoModel contato)
        {
            if (_bancoContext.Contatos.FirstOrDefault(x => x.Email == contato.Email) != null) return true;
            if (_bancoContext.Contatos.FirstOrDefault(x => x.Celular == contato.Celular) != null) return true;
            if (_bancoContext.Contatos.FirstOrDefault(x => x.Nome == contato.Nome) != null) return true;

            return false;
        }
    }
}
