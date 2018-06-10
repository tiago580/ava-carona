using System;

namespace ava.carona.app.domains
{
    public class OfertanteComoCaroneiroException : Exception
    {
        public OfertanteComoCaroneiroException(string msg): base(msg)
        {

        }
        public override string Message => "Não é possível utilizar o Ofertante como Caroneiro.";
    }
}