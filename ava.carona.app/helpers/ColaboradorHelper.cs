using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.helpers
{
    public static class ColaboradorHelper
    {
        public static void ValidarEIDNaoInformado(this string eid)
        {
            if (eid == null)
            {
                throw new ArgumentNullException("EID não informado");
            }
        }


    }
}
