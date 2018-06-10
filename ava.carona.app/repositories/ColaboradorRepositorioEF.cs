using ava.carona.app.domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.repositories
{
    public class ColaboradorRepositorioEF : ARepositorioEF<Colaborador>
    {
        public ColaboradorRepositorioEF(DbContext context) : base(context)
        {
        }
    }
}
