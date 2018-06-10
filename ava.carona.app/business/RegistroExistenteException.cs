using System;

namespace ava.carona.app.business
{
    public class RegistroExistenteException : Exception
    {
        public RegistroExistenteException()
        {
        }

        public RegistroExistenteException(string message) : base(message)
        {
        }

        public RegistroExistenteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}