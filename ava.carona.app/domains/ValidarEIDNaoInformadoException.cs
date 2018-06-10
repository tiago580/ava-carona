using System;

namespace ava.carona.app.domains
{
    public class ValidarEIDNaoInformadoException: Exception
    {
        public override string Message => "EID não informado.";
    }
}