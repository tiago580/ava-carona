using System;

namespace ava.carona.app.domains
{
    public class CaroneiroJaInclusoNaCaronaException : Exception
    {
        public CaroneiroJaInclusoNaCaronaException()
        {
        }

        public CaroneiroJaInclusoNaCaronaException(string message) : base(message)
        {
        }

        public CaroneiroJaInclusoNaCaronaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}