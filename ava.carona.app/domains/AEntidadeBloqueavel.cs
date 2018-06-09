using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public abstract class AEntidadeBloqueavel : AEntidade, IBloqueavel
    {
        private bool _Bloqueado;
        public void Bloquear()
        {
            _Bloqueado = true;
        }

        public void Desbloquear()
        {
            _Bloqueado = false;
        }

        public bool EstaBloqueado()
        {
            return _Bloqueado;
        }
    }
}
