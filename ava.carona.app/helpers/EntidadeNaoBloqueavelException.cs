using System;

namespace ava.carona.app.helpers
{
    public class EntidadeNaoBloqueavelException : Exception
    {
        public EntidadeNaoBloqueavelException()
        {
        }

        public EntidadeNaoBloqueavelException(string message) : base(message)
        {
        }

        public EntidadeNaoBloqueavelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}