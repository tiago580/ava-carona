using ava.carona.app.domains;
using ava.carona.app.repositories;
using System;
using System.Collections.Generic;
using ava.carona.app.helpers;

namespace ava.carona.app.business
{
    public class CaronaNegocio : ANegocio<Carona>, ICaronaNegocio
    {
        public CaronaNegocio(IRepositorio<Carona> repositorio) : base(repositorio)
        {
        }

        public IEnumerable<Carona> ListarPorOfertante(Colaborador ofertante)
        {
            ofertante.ValidarArgumentoNulo("Ofertante não informado");
            return _repositorio.Listar(carona => carona.Ofertante.Equals(ofertante));
        }
    }
}
