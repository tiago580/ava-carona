using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class ColaboradorBloqueadoException: Exception
    {
        //public override string Message => "Colaborador Bloqueado";
        public ColaboradorBloqueadoException(): base()
        {

        }
        public ColaboradorBloqueadoException(string msg): base(msg)
        {

        }
    }
}
