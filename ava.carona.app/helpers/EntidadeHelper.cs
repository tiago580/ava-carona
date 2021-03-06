﻿using ava.carona.app.domains;
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

        public static void ValidarBloqueio(this object entidade)
        {
            if (entidade is IBloqueavel)
            {
                var entidadeBloqueavel = entidade as IBloqueavel;
                if (entidadeBloqueavel.EstaBloqueado())
                {
                    throw new EntidadeBloqueadaException();
                }
            }
            else
            {
                throw new EntidadeNaoBloqueavelException();
            }
        }



    }
}
