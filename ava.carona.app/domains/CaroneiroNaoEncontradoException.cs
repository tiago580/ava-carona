using System;

namespace ava.carona.app.domains
{
    public class CaroneiroNaoEncontradoException : Exception
    {
        public override string Message => "Caroneiro não encontrado.";
    }
}