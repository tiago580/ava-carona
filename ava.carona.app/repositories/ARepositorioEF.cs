using ava.carona.app.domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ava.carona.app.repositories
{
    public class ARepositorioEF<T> : IRepositorio<T> where T: AEntidade
    {
        protected DbContext _context;

        public ARepositorioEF(DbContext context)
        {
            _context = context;
        }
        public T Adicionar(T obj)
        {
            var entry = _context.Add(obj);
            _context.SaveChanges();
            return entry.Entity;
        }

        public T Atualizar(T obj)
        {
            var entry = _context.Update(obj);
            _context.SaveChanges();
            return entry.Entity;
        }

        public int Deletar(T obj)
        {
            var entry = _context.Remove(obj);
            _context.SaveChanges();
            return entry.Entity.Id;
        }

        public virtual IEnumerable<T> Listar()
        {
            return Listar(e => true);
        }

        public virtual IEnumerable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public virtual T Obter(Expression<Func<T, bool>> predicate, bool noTrancking = true)
        {
            if (noTrancking)
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
            }
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

    }
}
