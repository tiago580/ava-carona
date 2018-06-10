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
    public class ColaboradorNegocioTest
    {
        const string EID_OFERTANTE = "t.vieira.da.rocha";
        const int PID_OFERTANTE = 1123;
        const string EID_CARONEIRO = "z.acsa.da.silva";
        const int PID_CARONEIRO = 1231;

        [TestMethod]
        public void AdicionarColaborador()
        {
            var colaborador = new Colaborador(EID_OFERTANTE);
            var colaborador2 = new Colaborador(EID_CARONEIRO);
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = 2;

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.Listar().Count();

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ObterColaborador()
        {
            var colaborador = new Colaborador(EID_OFERTANTE);
            var colaborador2 = new Colaborador(EID_CARONEIRO);
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = new Colaborador(EID_CARONEIRO);

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.Obter(c => c.Equals(esperado));

            Assert.AreEqual(esperado, resultado);
        }
        [TestMethod]
        public void RemoverColaborador()
        {
            var colaborador = new Colaborador(EID_OFERTANTE);
            var colaborador2 = new Colaborador(EID_CARONEIRO);
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = new Colaborador(EID_CARONEIRO);
            var valorEsperado = 2;

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.Deletar(esperado);

            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void ObterPorEID()
        {
            var colaborador = new Colaborador(EID_OFERTANTE);
            var colaborador2 = new Colaborador(EID_CARONEIRO);
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = new Colaborador(EID_CARONEIRO);

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.ObterPorEID(EID_CARONEIRO);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ObterPorPID()
        {
            var colaborador = new Colaborador(EID_OFERTANTE) { PID = PID_OFERTANTE};
            var colaborador2 = new Colaborador(EID_CARONEIRO) { PID = PID_CARONEIRO};
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = new Colaborador(EID_CARONEIRO);

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.ObterPorPID(PID_CARONEIRO);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void Listar()
        {
            var colaborador = new Colaborador(EID_OFERTANTE) { PID = PID_OFERTANTE};
            var colaborador2 = new Colaborador(EID_CARONEIRO) { PID = PID_CARONEIRO};
            var negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());
            var esperado = 2;

            negocio.Adicionar(colaborador);
            negocio.Adicionar(colaborador2);
            var resultado = negocio.Listar().Count();

            Assert.AreEqual(esperado, resultado);
        }
    }
}
