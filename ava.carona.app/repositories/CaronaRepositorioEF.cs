using ava.carona.app.domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.repositories
{
    public class CaronaRepositorioEF : ARepositorioEF<Carona>, ICaronaRepositorio
    {
        public CaronaRepositorioEF(DbContext context) : base(context)
        {
        }
    }
}
