using System;

namespace ava.carona.app.domains
{
    public class EntidadeBloqueadaException : Exception
    {
        public EntidadeBloqueadaException()
        {
        }

        public EntidadeBloqueadaException(string message) : base(message)
        {
        }

        public EntidadeBloqueadaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}