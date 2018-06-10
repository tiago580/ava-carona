using ava.carona.app.business;
using ava.carona.app.domains;
using ava.carona.app.repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ava.carona.app.test
{
    [TestClass]
    public class CaronaNegocioTest
    {
        const string EID_OFERTANTE = "t.vieira.da.rocha";
        const string EID_CARONEIRO = "z.acsa.da.silva";

        [TestMethod]
        public void Adicionar()
        {
            var negocio = new CaronaNegocio(new CaronaRepositorio());
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 6, new Endereco(), new Endereco());

            for (int i = 0; i < 5; i++)
            {
                carona.SolicitarCarona(new Colaborador($"{EID_CARONEIRO}-{i}"));
            }

            negocio.Adicionar(carona);

            var esperado = 1;

            Assert.AreEqual(esperado, negocio.Listar().Count());
        }

        [TestMethod]
        public void ListarPorOfertante()
        {
            var negocio = new CaronaNegocio(new CaronaRepositorio());
            var solicitacoesEsperadas = 0;
            var esperado = 1;
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 6, new Endereco(), new Endereco());

            for (int i = 0; i < 5; i++)
            {
                carona.SolicitarCarona(new Colaborador($"{EID_CARONEIRO}-{i}"));
                solicitacoesEsperadas++;
            }

            negocio.Adicionar(carona);


            IList<Carona> caronas = negocio.ListarPorOfertante(ofertante).ToList();

            Assert.AreEqual(esperado, negocio.ListarPorOfertante(ofertante).Count());
            Assert.AreEqual(solicitacoesEsperadas, caronas[0].Caroneiros.Count);
        }
    }
}
