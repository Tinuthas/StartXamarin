using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _06_Fiap.Web.AspNet.Models;
using _06_Fiap.Web.AspNet.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _06_Fiap.Web.AspNet.Controllers
{
    public class CorridaController : Controller
    {
        private RacerContext _context;

        public CorridaController(RacerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Pesquisar(string termoPesquisa)
        {
            var lista = _context.Corridas
                .Where(c => c.Nome.Contains(termoPesquisa)).Include(c => c.Trajeto).ToList();
            //retorna para a página Listar com a lista filtrada
            return View("Listar",lista);
        }

        [HttpPost]
        public IActionResult Excluir(int codigo)
        {
            var corrida = _context.Corridas.Find(codigo);
            _context.Corridas.Remove(corrida);
            _context.SaveChanges();
            TempData["mensagem"] = "Removido!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(_context.Corridas.Find(id));
        }

        [HttpPost]
        public IActionResult Editar(Corrida corrida)
        {
            _context.Corridas.Update(corrida);
            _context.SaveChanges();
            TempData["mensagem"] = "Atualizado!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            //Include - inclui o relacionamento na pesquisa
            return View(_context.Corridas.Include(c => c.Trajeto).ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
            _context.SaveChanges();
            TempData["mensagem"] = "Cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}