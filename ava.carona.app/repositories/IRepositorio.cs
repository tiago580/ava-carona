using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ava.carona.app.repositories
{
    public interface IRepositorio<T> 
    {
        T Adicionar(T obj);
        T Atualizar(T obj);
        T Obter(Expression<Func<T, bool>> predicate);
        T Obter(Expression<Func<T, bool>> predicate, bool noTrancking = true);
        IEnumerable<T> Listar();
        IEnumerable<T> Listar(Expression<Func<T, bool>> predicate);
        int Deletar(T obj);
    }
}
