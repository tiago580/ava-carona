using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public abstract class AEntidadeBloqueavel : AEntidade, IBloqueavel
    {
        public AEntidadeBloqueavel(): base()
        {

        }
        public bool Bloqueado { get; set; }
        public void Bloquear()
        {
            Bloqueado = true;
        }

        public void Desbloquear()
        {
            Bloqueado = false;
        }

        public bool EstaBloqueado()
        {
            return Bloqueado;
        }
    }
}
