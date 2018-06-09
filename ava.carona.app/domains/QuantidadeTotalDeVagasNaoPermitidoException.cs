using System;

namespace ava.carona.app.domains
{
    public class QuantidadeTotalDeVagasNaoPermitidoException : Exception
    {
        public QuantidadeTotalDeVagasNaoPermitidoException()
        {
        }

        public QuantidadeTotalDeVagasNaoPermitidoException(string message) : base(message)
        {
        }

        public QuantidadeTotalDeVagasNaoPermitidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}