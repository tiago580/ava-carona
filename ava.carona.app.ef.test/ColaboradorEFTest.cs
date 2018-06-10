using ava.carona.app.business;
using ava.carona.app.domains;
using ava.carona.app.repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.ef.test
{
    [TestClass]
    public class ColaboradorEFTest
    {
        [TestMethod]
        public void Adicionar()
        {
            using (var context = new AppContext())
            {
                var negocio = new ColaboradorNegocio(new ColaboradorRepositorioEF(context));
                var colaborador = new Colaborador("t.vieira.da.rocha") { PID = 1231, Nome = "Tiago Vieira da Rocha" };

                var resultado = negocio.Adicionar(colaborador);

                Assert.AreEqual(colaborador, resultado);
            }
    
        }
    }
}
