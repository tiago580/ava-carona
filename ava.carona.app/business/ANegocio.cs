﻿using ava.carona.app.domains;
using ava.carona.app.repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ava.carona.app.helpers;

namespace ava.carona.app.business
{
    public abstract class ANegocio<T> : INegocio<T> where T : AEntidade
    {
        protected IRepositorio<T> _repositorio;
        public ANegocio(IRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }
        public T Adicionar(T obj)
        {
            obj.ValidarArgumentoNulo();
            if (!ExisteRegistro(obj))
            {
                _repositorio.Adicionar(obj);
            }

            return obj;
        }

        public T Atualizar(T obj)
        {
            return _repositorio.Atualizar(obj);
        }

        public int Deletar(T obj)
        {
            return _repositorio.Deletar(obj);
        }

        public bool ExisteRegistro(T obj)
        {
            return Obter(e => e.Equals(obj)) != null;
        }

        public IEnumerable<T> Listar()
        {
            return _repositorio.Listar();
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            predicate.ValidarArgumentoNulo();
            return _repositorio.Listar(predicate);
        }

        public T Obter(Expression<Func<T, bool>> predicate)
        {
            predicate.ValidarArgumentoNulo();
            return _repositorio.Obter(predicate);
        }

        public T ObterPorId(int id)
        {
            return _repositorio.Obter(e => e.Id == id);
        }

    }
}