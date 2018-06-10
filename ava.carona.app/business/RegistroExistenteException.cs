using System;

namespace ava.carona.app.business
{
    public class RegistroExistenteException : Exception
    {
        public override string Message => "Registro já inserido no sistema.";
    }
}