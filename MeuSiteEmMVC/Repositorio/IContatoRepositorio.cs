using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);

        List<ContatoModel> BuscarTodos();

        ContatoModel ListarPorId(int id);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
