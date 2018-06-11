using AutoMapper;
using ava.carona.app.domains;
using ava.carona.app.facade;
using ava.carona.app.webapi.dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ava.carona.app.helpers;

namespace ava.carona.app.webapi.services
{
    [Route("api/colaborador")]
    public class ColaboradorService: Controller
    {
        private IFachada fachada;

        public ColaboradorService(IFachada fachada)
        {
            this.fachada = fachada;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ColaboradorDTO colaborador)
        {
            try
            {

                var result = fachada.CriarColaborador(Mapper.Map<Colaborador>(colaborador));
                return CreatedAtRoute("GetColaborador", new { id = result.Id }, result);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetColaborador")]
        public IActionResult Obter(int id)
        {
            try
            {
                var colaborador = fachada.ObterColaboradorPorId(id);
                if (colaborador == null)
                {
                    return NotFound();

                }
                return Ok(Mapper.Map<ColaboradorDTO>(colaborador));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var colaboradores = fachada.ListarColaboradores();
                var result = colaboradores.Select(c => Mapper.Map<ColaboradorDTO>(c)).ToList();
                return Ok(colaboradores);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Colaborador item)
        {
            try
            {
                var colab = ObterColaborador(id);
                // problemas com o autoMapper
                colab.Nome = item.Nome;
                colab.EID = item.EID;
                colab.PID = item.PID;
                var colaboradores = fachada.AtualizarColaborador(colab, id);
                return NoContent();

            }
            catch (RegistroNaoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch("{id}")]
        public IActionResult Atualizar([FromBody] JsonPatchDocument<Colaborador> patch, int id)
        {
            try
            {
                var colab = ObterColaborador(id);

                patch.ApplyTo(colab);

                var colaboradores = fachada.AtualizarColaborador(colab, id);
                return NoContent();

            }
            catch (RegistroNaoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var result = fachada.DeletarColaborador(id);
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("bloquear/{id}")]
        public IActionResult Bloquear(int id)
        {
            try
            {
                var colaborador = fachada.ObterColaboradorPorId(id);
                colaborador.Bloquear();
                fachada.BloquearColaborador(colaborador, id);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }



        private Colaborador ObterColaborador(int id)
        {
            var colab = fachada.ObterColaboradorPorId(id);
            if (colab == null)
            {
                throw new RegistroNaoEncontradoException();
            }
            return colab;

        }

    }
}
