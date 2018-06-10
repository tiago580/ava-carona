using ava.carona.app.repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ava.carona.app.ef.test
{
    [TestClass]
    public class MainTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            using (var repositorio = new AppContext())
            {
                repositorio.AtivarBaseDeDados();
            }
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            using (var repositorio = new AppContext())
            {
                repositorio.DesativarBaseDeDados();
            }
        }
    }
}
