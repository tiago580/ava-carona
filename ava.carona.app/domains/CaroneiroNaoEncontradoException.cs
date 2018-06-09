using System;

namespace ava.carona.app.domains
{
    public class CaroneiroNaoEncontradoException : Exception
    {
        public CaroneiroNaoEncontradoException()
        {
        }

        public CaroneiroNaoEncontradoException(string message) : base(message)
        {
        }

        public CaroneiroNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}