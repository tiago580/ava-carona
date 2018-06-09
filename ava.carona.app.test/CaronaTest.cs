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
        const string EID_OFERTANTE = "t.vieira.da.rocha";
        const string EID_CARONEIRO = "z.acsa.da.silva";
        [TestMethod]
        [ExpectedException(typeof(ColaboradorBloqueadoException))]
        public void BloquearColaboradorOferecerCarona()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            ofertante.Bloquear();
            var carona = new Carona();

            carona.Ofertante = ofertante;

        }

        [TestMethod]
        [ExpectedException(typeof(ColaboradorBloqueadoException))]
        public void BloquearColaboradorPedirCarona()
        {
            var caroneiro = new Colaborador(EID_CARONEIRO);
            var ofertante = new Colaborador(EID_OFERTANTE);
            caroneiro.Bloquear();
            var carona = new Carona(ofertante, 1);
            carona.SolicitarCarona(caroneiro);

        }

        [TestMethod]
        public void PermitirCarona()
        {
            var caroneiro = new Colaborador(EID_CARONEIRO);
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 1);
            carona.SolicitarCarona(caroneiro);
            var esperado = StatusCarona.PERMITIDO;

            var resultado = carona.PermitirCarona(caroneiro);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void NegarCarona()
        {
            var caroneiro = new Colaborador(EID_CARONEIRO);
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante,1);
            carona.SolicitarCarona(caroneiro);
            var esperado = StatusCarona.NEGADO;

            var resultado = carona.NegarCarona(caroneiro);

            Assert.AreEqual(esperado, resultado);
        }
        [TestMethod]
        [ExpectedException(typeof(CaronaBloqueadaException))]
        public void BloquearCarona()
        {
            var caroneiro = new Colaborador(EID_CARONEIRO);
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 1);
            carona.Bloquear();

            carona.SolicitarCarona(caroneiro);

        }

        [TestMethod]
        [ExpectedException(typeof(OfertanteComoCaroneiroException))]
        public void BloquearCaronaOfertante()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 1);

            carona.SolicitarCarona(ofertante);

        }
        [TestMethod]
        [ExpectedException(typeof(QuantidadeTotalDeVagasNaoPermitidoException))]
        public void LimiteMaximoDeTotalVagasNaoPermitido()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 7);
        }
        [TestMethod]
        [ExpectedException(typeof(QuantidadeTotalDeVagasNaoPermitidoException))]
        public void LimiteMinimoDeTotalVagasNaoPermitido()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(CaroneiroJaInclusoNaCaronaException))]
        public void CaroneiroJaInclusoNaCarona()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 1);
            var caroneiro = new Colaborador(EID_CARONEIRO);

            carona.SolicitarCarona(caroneiro);
            carona.SolicitarCarona(caroneiro);
        }

        [TestMethod]
        [ExpectedException(typeof(NaoHaVagasDisponiveisException))]
        public void NaoHaVagasDisponiveis()
        {
            var ofertante = new Colaborador(EID_OFERTANTE);
            var carona = new Carona(ofertante, 1);
            var caroneiro = new Colaborador(EID_CARONEIRO);
            var caroneiro2 = new Colaborador("r.teste.com");
            var caroneiro3 = new Colaborador("r.teste.com1");

            carona.SolicitarCarona(caroneiro);
            carona.SolicitarCarona(caroneiro2);
            carona.SolicitarCarona(caroneiro3);

            carona.PermitirCarona(caroneiro);
            carona.PermitirCarona(caroneiro2);
            carona.PermitirCarona(caroneiro3);

        }
    }
}
