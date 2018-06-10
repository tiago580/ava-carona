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
        public ColaboradorNegocio(IColaboradorRepositorio repositorio) : base(repositorio)
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

        public override Colaborador Atualizar(Colaborador obj, int id)
        {
            if (Obter(
                    c => c.Id != obj.Id &&
                    (
                        c.EID == obj.EID ||
                        (
                            c.PID > 0 &&
                            c.PID == obj.PID
                        )
                    )
                ) != null)
            {
                throw new ColaboradorJaCadastradoException($"Colaborador já cadastrado. EID = {obj.EID}, PID = {obj.PID} ");
            }
            return base.Atualizar(obj, id);
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
