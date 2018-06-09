using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.helpers
{
    public static class EntidadeHelper
    {
        public static void ValidarArgumentoNulo(this object entidade, string msg = null)
        {
            if (entidade == null)
            {
                if (msg != null)
                {
                    throw new ArgumentNullException(msg);
                }

                throw new ArgumentNullException("Parâmetro nulo não permitido");
            }
        }

        public static void ValidarEIDNaoInformado(this string eid)
        {
            if (eid == null)
            {
                throw new ArgumentNullException("EID não informado");
            }
        }
    }
}
