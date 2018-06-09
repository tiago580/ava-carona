using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public interface IBloqueavel
    {
        void Bloquear();
        void Desbloquear();
        bool EstaBloqueado();
    }
}
