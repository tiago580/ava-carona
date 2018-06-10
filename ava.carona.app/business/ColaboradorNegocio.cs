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

            var colaborador = _repositorio.Obter(c => c.EID == eid, false);
            if (colaborador == null)
            {
                throw new RegistroNaoEncontradoException();
            }

            return colaborador;
        }

        public Colaborador ObterPorPID(int pid)
        {
            var colaborador = _repositorio.Obter(c => c.PID == pid, false);
            if (colaborador == null)
            {
                throw new RegistroNaoEncontradoException();
            }
            return colaborador;
        }
    }
}
