using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.helpers
{
    public static class ColaboradorHelper
    {
        const int LIMITE_MINIMO_CARACTERES_EID = 3;
        const int LIMITE_MAXIMO_CARACTERES_EID = 20;

        public static void ValidarEIDNaoInformado(this string eid)
        {
            if (eid == null)
            {
                throw new ArgumentNullException("EID não informado");
            }
        }
        public static void ValidarLimiteMinimoEID(this string eid)
        {
            ValidarEIDNaoInformado(eid);
            if (eid.Length < LIMITE_MINIMO_CARACTERES_EID)
            {
                throw new ColaboradorLimiteMinimoDeCaracteresNaoAtingidoException();
            }
        }
        public static void ValidarLimiteMaximoEID(this string eid)
        {
            ValidarEIDNaoInformado(eid);
            if (eid.Length > LIMITE_MAXIMO_CARACTERES_EID)
            {
                throw new ColaboradorLimiteMaximoDeCaracteresExcedidoException();
            }
        }
        public static void ValidarEID(this string eid)
        {
            ValidarLimiteMaximoEID(eid);
            ValidarLimiteMinimoEID(eid);
        }


    }
}
