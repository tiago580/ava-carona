using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.helpers
{
    public static class CaronaHelper
    {
        public static void ValidarVagas(this int vagas, int limiteMaximo, int limiteMinimo)
        {
            if (vagas > limiteMaximo)
            {
                throw new QuantidadeTotalDeVagasNaoPermitidoException($"A quantidade máxima de vagas é {limiteMaximo}");
            }
            if (vagas < limiteMinimo)
            {
                throw new QuantidadeTotalDeVagasNaoPermitidoException($"A quantidade mínima de vagas é {limiteMinimo}");
            }
        }
    }
}
