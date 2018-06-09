using System;

namespace ava.carona.app.domains
{
    public class OfertanteComoCaroneiroException : Exception
    {
        public OfertanteComoCaroneiroException()
        {
        }

        public OfertanteComoCaroneiroException(string message) : base(message)
        {
        }

        public OfertanteComoCaroneiroException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}