using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class ColaboradorLimiteMinimoDeCaracteresNaoAtingidoException: Exception
    {
        public override string Message => "[EID] - Limite mínimo de caracteres não atingido.";
    }
}
