using ava.carona.app.domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.test
{
    [TestClass]
    public class CaronaTest
    {
        [TestMethod]
        [ExpectedException(typeof(ColaboradorBloqueadoException))]
        public void BloquearColaboradorOferecerCarona()
        {
            var colaborador = new Colaborador();
            colaborador.Bloquear();
            var carona = new Carona();

            carona.Ofertante = colaborador;

        }

        [TestMethod]
        [ExpectedException(typeof(ColaboradorBloqueadoException))]
        public void BloquearColaboradorPedirCarona()
        {
            var caroneiro = new Colaborador();
            caroneiro.Bloquear();
            var carona = new Carona();
            carona.SolicitarCarona(caroneiro);

        }

        [TestMethod]
        public void PermitirCarona()
        {
            var caroneiro = new Colaborador();
            var carona = new Carona();
            carona.SolicitarCarona(caroneiro);
            var esperado = StatusCarona.PERMITIDO;

            var resultado = carona.PermitirCarona(caroneiro);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void NegarCarona()
        {
            var caroneiro = new Colaborador();
            var carona = new Carona();
            carona.SolicitarCarona(caroneiro);
            var esperado = StatusCarona.NEGADO;

            var resultado = carona.NegarCarona(caroneiro);

            Assert.AreEqual(esperado, resultado);
        }
        [TestMethod]
        [ExpectedException(typeof(CaronaBloqueadaException))]
        public void BloquearCarona()
        {
            var caroneiro = new Colaborador();
            var carona = new Carona();
            carona.Bloquear();

            carona.SolicitarCarona(caroneiro);

        }
    }
}
