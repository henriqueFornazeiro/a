﻿using System.Linq;
using _04_Fiap.Web.AspNet.Models;
using _04_Fiap.Web.AspNet.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _04_Fiap.Web.AspNet.Controllers
{
    public class SerieController : Controller
    {
        //Tipo o "em", vai acessar as coisas no banco
        private BancoContext _context;

        //O contexto será instanciando pelo framework
        public SerieController(BancoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Editar(Serie serie)
        {
            //atualiza no banco
            _context.Attach(serie).State = EntityState.Modified;
            _context.SaveChanges();
            //mensagem de sucesso para a tela
            TempData["msg"] = "Atualizado!";
            //redirect para o método de listagem
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Pesquisar a serie no banco de dados
            var serie = _context.Series.Find(id);
            //Retornar a view com a serie que será atualizada
            return View(serie);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_context.Series.ToList());
        }

        [HttpPost]
        public IActionResult Cadastrar(Serie serie)
        {
            _context.Series.Add(serie);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var removeSerie = _context.Series.Find(id);
            _context.Series.Remove(removeSerie);
            _context.SaveChanges();
            TempData["msg"] = "Excluido com sucesso!";
            return RedirectToAction("Listar");
        }

    }
}
