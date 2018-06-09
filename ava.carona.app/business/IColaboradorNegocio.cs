using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.business
{
    public interface IColaboradorNegocio: INegocio<Colaborador>
    {
        Colaborador ObterPorEID(string eid);
        Colaborador ObterPorPID(int pid);

    }
}
