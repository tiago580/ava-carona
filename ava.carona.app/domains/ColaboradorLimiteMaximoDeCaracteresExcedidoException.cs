using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class ColaboradorLimiteMaximoDeCaracteresExcedidoException: Exception
    {
        public override string Message => "Limite máximo de caracteres excedido";
    }
}
