using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.business
{
    public interface ICaronaNegocio: INegocio<Carona>
    {
        IEnumerable<Carona> ListarPorOfertante(Colaborador ofertante);
    }
}
