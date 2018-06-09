using ava.carona.app.domains;
using ava.carona.app.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ava.carona.app.helpers;

namespace ava.carona.app.business
{
    public class ColaboradorNegocio : ANegocio<Colaborador>, IColaboradorNegocio
    {
        public ColaboradorNegocio(IRepositorio<Colaborador> repositorio) : base(repositorio)
        {
        }

        public Colaborador ObterPorEID(string eid)
        {
            eid.ValidarEIDNaoInformado();
            return _repositorio.Obter(c => c.EID == eid);
        }

        public Colaborador ObterPorPID(int pid)
        {
            return _repositorio.Obter(c => c.PID == pid);
        }
    }
}
