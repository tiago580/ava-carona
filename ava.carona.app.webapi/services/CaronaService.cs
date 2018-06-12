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
    [Route("api/carona")]
    public class CaronaService: Controller
    {
        private IFachada fachada;

        public CaronaService(IFachada fachada)
        {
            this.fachada = fachada;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CaronaDTO caronaDTO)
        {
            try
            {
                var carona = Mapper.Map<Carona>(caronaDTO);

                var _origem = Mapper.Map<Endereco>(caronaDTO.Origem);
                _origem.Tipo = TipoEndereco.ORIGEM;
                var _destino = Mapper.Map<Endereco>(caronaDTO.Destino);
                _destino.Tipo = TipoEndereco.DESTINO;
                carona.Enderecos.Add(_origem);
                carona.Enderecos.Add(_destino);

                carona.Ofertante = fachada.ObterColaboradorPorId(caronaDTO.Ofertante.Id);

                var _carona = fachada.CriarCarona(carona);

                var result = new CaronaDTO(_carona);

                return CreatedAtRoute("GetCarona", new { id = _carona.Id }, result);
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
                var caronas = fachada.ListarCaronas();
                var result = caronas.Select(c => new CaronaDTO(c)).ToList();
                return Ok(result);
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
                var carona = fachada.ObterCaronaPorId(id);
                carona.Bloquear();
                fachada.AtualizarCarona(carona, id);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("solicitar/{id}")]
        public IActionResult SOlicitar(int id, [FromBody] Colaborador colaborador)
        {
            try
            {
                var carona = fachada.SolicitarCarona(id, colaborador);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("permitir/{id}")]
        public IActionResult Permitir(int id, [FromBody] Colaborador colaborador)
        {
            try
            {
                Carona carona = fachada.PermitirCarona(id, colaborador);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("negar/{id}")]
        public IActionResult Negar(int id, [FromBody] Colaborador colaborador)
        {
            try
            {
                Carona carona = fachada.NegarCarona(id, colaborador);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("ofertante/{id}")]
        public IActionResult Listar(int id)
        {
            try
            {
                var caronas = fachada.ListarCaronaPorOfertante(id);
                var result = caronas.Select(c => new CaronaDTO(c)).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCarona")]
        public IActionResult Obter(int id)
        {
            try
            {
                var carona = ObterCarona(id);
                return Ok(new CaronaDTO(carona));
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
                fachada.DeletarCarona(id);
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

        private Carona ObterCarona(int id)
        {
            var carona = fachada.ObterCaronaPorId(id);
            if (carona == null)
            {
                throw new RegistroNaoEncontradoException();
            }
            return carona;

        }




    }
}
