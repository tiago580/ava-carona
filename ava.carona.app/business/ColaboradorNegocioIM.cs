using ava.carona.app.domains;
using ava.carona.app.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ava.carona.app.helpers;

namespace ava.carona.app.business
{
    public class ColaboradorNegocioIM : ANegocio<Colaborador>, IColaboradorNegocio
    {
        public ColaboradorNegocioIM(IRepositorio<Colaborador> repositorio) : base(repositorio)
        {
        }

        public Colaborador ObterPorEID(string eid)
        {
            eid.ValidarEIDNaoInformado();


            if (!ExisteRegistro(new Colaborador(eid)))
            {
                throw new RegistroNaoEncontradoException();
            }

            return _repositorio.Obter(c => c.EID == eid);
        }

        public Colaborador ObterPorPID(int pid)
        {
            var colaborador = _repositorio.Obter(c => c.PID == pid);
            if (colaborador == null)
            {
                throw new RegistroNaoEncontradoException();
            }
            return colaborador;
        }
    }
}
