using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_contatoRepositorio.BuscarTodos());
        }

        public IActionResult Criar()
        {
            return View();
        }
            
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato registrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Oops! Não conseguimos cadastrar o seu contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Oops! Não conseguimos alterar o contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Editar(int id)
        {
            return View(_contatoRepositorio.ListarPorId(id));
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            return View(_contatoRepositorio.ListarPorId(id));
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato removido com sucesso";
                }

                else
                {
                    TempData["MensagemErro"] = "Oops! Não conseguimos remover o contato, tente novamente.";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Oops! Não conseguimos remover o contato, tente novamente. Mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
