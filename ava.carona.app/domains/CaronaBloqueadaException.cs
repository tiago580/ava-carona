using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class CaronaBloqueadaException: Exception
    {
        public override string Message => "Não é possível solicitar uma carona enquanto ela estiver bloqueada.";
    }
}
