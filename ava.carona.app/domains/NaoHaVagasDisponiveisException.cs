using System;

namespace ava.carona.app.domains
{
    public class NaoHaVagasDisponiveisException : Exception
    {
        public override string Message => "Não há vagas disponíveis";
    }
}