using System;

namespace ava.carona.app.business
{
    public class RegistroNaoEncontradoException : Exception
    {
        public RegistroNaoEncontradoException()
        {
        }

        public RegistroNaoEncontradoException(string message) : base(message)
        {
        }

        public RegistroNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}