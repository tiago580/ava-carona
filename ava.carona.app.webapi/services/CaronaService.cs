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

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var caronas = fachada.ListarCaronas();
                return Ok(caronas);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        

    }
}
