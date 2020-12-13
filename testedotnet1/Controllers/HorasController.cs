﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testedotnet1.Models;
using testedotnet1.Repository;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorasController : ControllerBase
    {
        private HorasRepository _HR;
        public HorasRepository HR
        {
            get
            {
                if (_HR == null)
                    _HR = new HorasRepository();
                return _HR;
            }
        }

        [HttpGet]
        public IActionResult HorasRegistradas()
        {
            var hora = HR.GetRegistros();
            if (hora == null)
                return NotFound();
            return Ok(hora);
        }

        [HttpGet("{id}")]
        public IActionResult HoraRegistrada(int id)
        {
            var hora = HR.GetRegistro(id);
            if (hora == null)
                return NotFound();
            return Ok(hora);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHoraAsync(/*[FromBody] Hora_trabalhada value*/)
        {
            var hora = 0;
            if (hora == null)
                return BadRequest();
            return Ok(hora);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarHora([FromBody] Hora_trabalhada value)
        {
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirHora([FromBody] Hora_trabalhada value)
        {
            return null;
        }


        //[HttpGet]
        //public IActionResult ListaDeLivros()
        //{
        //    var lista = _repo.All.Select(l => l.ToModel()).ToList();
        //    return Ok(lista);
        //}

        //[HttpGet("{id}")]
        //public IActionResult Recuperar(int id)
        //{
        //    var model = _repo.Find(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(model.ToModel());
        //}

        //[HttpPost]
        //public IActionResult Incluir([FromBody] LivroUpload model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var livro = model.ToLivro();
        //        _repo.Incluir(livro);
        //        var uri = Url.Action("Recuperar", new { id = livro.Id });
        //        return Created(uri, livro); //201
        //    }
        //    return BadRequest();
        //}

        //[HttpPut]
        //public IActionResult Alterar([FromBody] LivroUpload model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var livro = model.ToLivro();
        //        if (model.Capa == null)
        //        {
        //            livro.ImagemCapa = _repo.All
        //                .Where(l => l.Id == livro.Id)
        //                .Select(l => l.ImagemCapa)
        //                .FirstOrDefault();
        //        }
        //        _repo.Alterar(livro);
        //        return Ok(); //200
        //    }
        //    return BadRequest();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Remover(int id)
        //{
        //    var model = _repo.Find(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    _repo.Excluir(model);
        //    return NoContent(); //203
        //}
    }
}
