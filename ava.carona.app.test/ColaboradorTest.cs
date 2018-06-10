using ava.carona.app.domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ava.carona.app.test
{
    [TestClass]
    public class ColaboradorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ColaboradorLimiteMinimoDeCaracteresNaoAtingidoException))]
        public void LimiteMinimoDeCaracteresNaoAtingidoTest()
        {
            var colaborador = new Colaborador("1");
        }
        [TestMethod]
        [ExpectedException(typeof(ColaboradorLimiteMaximoDeCaracteresExcedidoException))]
        public void LimiteMaximoDeCaracteresExcedidoTest()
        {
            var colaborador = new Colaborador("012345678901234567890");
            
        }
    }
}
