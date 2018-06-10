using System;

namespace ava.carona.app.domains
{
    public class QuantidadeTotalDeVagasNaoPermitidoException : Exception
    {
        public QuantidadeTotalDeVagasNaoPermitidoException(string msg): base(msg)
        {

        }
        public override string Message => "Quantidade total de vagas não permitido."; 
    }
}