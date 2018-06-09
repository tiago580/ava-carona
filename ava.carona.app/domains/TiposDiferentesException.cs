using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class TiposDiferentesException: Exception
    {
        public override string Message => "Não é possível comparar objetos de tipos diferentes.";
    }
}
