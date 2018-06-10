using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace ava.carona.app.repositories
{
    public abstract class ARepositorioIM<T> : IRepositorio<T> where T : AEntidade
    {
        private IList<T> _entidades = new List<T>();
        public T Adicionar(T obj)
        {
            obj.Id = obterId();
            _entidades.Add(obj);
            return obj;
        }

        public T Atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public int Deletar(T obj)
        {
            _entidades.Remove(obj);
            return obj.Id;
        }

        public IEnumerable<T> Listar()
        {
            return Listar(e => true);
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate).ToList();
        }

        public T Obter(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public T Obter(Expression<Func<T, bool>> predicate, bool noTrancking = true)
        {
            throw new NotImplementedException();
        }

        private int obterId()
        {
            if (_entidades.Count == 0)
            {
                return 1;
            }
            return _entidades.Where(e => true). Max(e => e.Id) + 1;
        }
    }
}
