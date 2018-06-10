using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class RegistroNaoEncontradoException: Exception
    {
        public override string Message => "Registro não encontrado.";
    }
}
