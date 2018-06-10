using System;

namespace ava.carona.app.domains
{
    public class CaroneiroJaInclusoNaCaronaException : Exception
    {
        public override string Message => "Caroneiro já registrado para esta carona.";
    }
}