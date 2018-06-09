using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ava.carona.app.business
{
    public interface INegocio<T>
    {
        T Adicionar(T obj);
        T Atualizar(T obj);
        T Obter(Expression<Func<T, bool>> predicate);
        T ObterPorId(int id);
        IEnumerable<T> Listar();
        IEnumerable<T> Listar(Expression<Func<T, bool>> predicate);
        int Deletar(T obj);
        bool ExisteRegistro(T obj);

    }
}
