using System;
using System.Collections.Generic;
using System.Text;
using ava.carona.app.business;
using ava.carona.app.domains;
using ava.carona.app.repositories;
using Microsoft.EntityFrameworkCore;

namespace ava.carona.app.facade
{
    public class Fachada : IFachada
    {
        private IColaboradorNegocio colaboradorNegocio;
        private ICaronaNegocio caronaNegocio;
        public Fachada(
            DbContext context,
            IColaboradorNegocio colaboradorNegocio,
            ICaronaNegocio caronaNegocio
            )
        {
            this.colaboradorNegocio = colaboradorNegocio;
            this.caronaNegocio = caronaNegocio;
        }

        #region Colaborador
        public Colaborador CriarColaborador(Colaborador colaborador)
        {
            colaborador.Validar();
            return colaboradorNegocio.Adicionar(colaborador);
        }

        public IEnumerable<Colaborador> ListarColaboradores()
        {
            return colaboradorNegocio.Listar();
        }

        public Colaborador ObterColaborador(Colaborador colaborador)
        {
            return colaboradorNegocio.Obter(c => c.Equals(colaborador));
        }

        public int DeletarColaborador(int id)
        {
            return colaboradorNegocio.Deletar(new Colaborador() { Id = id});
        }

        public Colaborador AtualizarColaborador(Colaborador colaborador, int id)
        {
            colaborador.Validar();
            return colaboradorNegocio.Atualizar(colaborador, id);
        }
        public Colaborador BloquearColaborador(Colaborador colaborador, int id)
        {
            return colaboradorNegocio.Atualizar(colaborador, id);
        }

        public Colaborador ObterColaboradorPorId(int id)
        {
            return colaboradorNegocio.ObterPorId(id);
        }

        #endregion

        #region Carona
        public Carona CriarCarona(Carona carona)
        {
            carona.Validar();
            return caronaNegocio.Adicionar(carona);
        }

        public IEnumerable<Carona> ListarCaronas()
        {
            return caronaNegocio.Listar();
        }

        public Carona ObterCarona(Carona carona)
        {
            return caronaNegocio.Obter(c => c.Equals(carona));
        }

        public Carona ObterCaronaPorId(int id)
        {
            return caronaNegocio.ObterPorId(id);
        }

        public int DeletarCarona(int id)
        {
            return caronaNegocio.Deletar(new Carona() { Id = id });
        }

        public Carona AtualizarCarona(Carona carona, int id)
        {
            return caronaNegocio.Atualizar(carona, id);
        }

        public IEnumerable<Carona> ListarCaronaPorOfertante(int ofertanteId)
        {
            return caronaNegocio.ListarPorOfertante(new Colaborador() { Id = ofertanteId });
        }

        #endregion

    }
}
