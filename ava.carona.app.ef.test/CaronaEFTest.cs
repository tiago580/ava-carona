using ava.carona.app.business;
using ava.carona.app.domains;
using ava.carona.app.repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ava.carona.app.ef.test
{
    [TestClass]
    public class CaronaEFTest
    {
        private const string EID_OFERTANTE = "z.acsa.silva";
        private const string EID_CARONEIRO = "t.vieira";

        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new AppContext())
            {
                var negocio = new ColaboradorNegocio(new ColaboradorRepositorioEF(context));
                var ofertante = new Colaborador(EID_OFERTANTE) { PID = 1631, Nome = "Zíbia Acsa do Carmo Silva" };
                var caroneiro = new Colaborador(EID_CARONEIRO) { PID = 1233, Nome = "Tiago Vieira da Rocha" };

                negocio.Adicionar(ofertante);
                negocio.Adicionar(caroneiro);

            }
    
        }
        [TestCleanup]
        public void TestCleanup()
        {
            using (var context = new AppContext())
            {
                var negocio = new CaronaNegocio(new CaronaRepositorioEF(context));
                var negocioColaborador = new ColaboradorNegocio(new ColaboradorRepositorioEF(context));


                var caronas = negocio.Listar();
                if (caronas != null)
                {
                    foreach (var item in caronas)
                    {
                        negocio.Deletar(item);

                    }
                }

                negocioColaborador.Deletar(new Colaborador(EID_OFERTANTE));
                negocioColaborador.Deletar(new Colaborador(EID_CARONEIRO));

            }

        }

        [TestMethod]
        public void Adicionar()
        {
            using (var context = new AppContext())
            {
                var negocio = new CaronaNegocio(new CaronaRepositorioEF(context));
                var negocioColaborador = new ColaboradorNegocio(new ColaboradorRepositorioEF(context));
                var ofertante = negocioColaborador.ObterPorEID(EID_OFERTANTE);
                var caroneiro = negocioColaborador.ObterPorEID(EID_CARONEIRO);
                var carona = new Carona(ofertante, 6, new Endereco(), new Endereco());
                var esperado = 1;

                negocio.Adicionar(carona);

                Assert.AreEqual(esperado, negocio.Listar().Count());


            }


        }
    }
}
