using ava.carona.app.domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ava.carona.app.repositories
{
    public class CaronaRepositorioEF : ARepositorioEF<Carona>, ICaronaRepositorio
    {
        public CaronaRepositorioEF(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Carona> Listar()
        {
            return Listar(c => true);
        }

        public override IEnumerable<Carona> Listar(Expression<Func<Carona, bool>> predicate)
        {
            var context = _context as AppContext;
            return context.Caronas
                .Include(c => c.Enderecos)
                .Include(c => c.Ofertante)
                .Include(c => c.Caroneiros)
                    .ThenInclude(ca => ca.Caroneiro)
                .AsNoTracking().Where(predicate).ToList();
        }

        public override Carona Obter(Expression<Func<Carona, bool>> predicate, bool noTrancking = true)
        {
            var context = _context as AppContext;
            return context.Caronas
                .Include(c => c.Enderecos)
                .Include(c => c.Ofertante)
                .Include(c => c.Caroneiros)
                    .ThenInclude(ca => ca.Caroneiro)
                .Where(predicate)
                .FirstOrDefault();

        }
    }
}
