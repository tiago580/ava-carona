using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class ColaboradorBloqueadoException: Exception
    {
        public ColaboradorBloqueadoException(): base()
        {

        }
        public ColaboradorBloqueadoException(string msg): base(msg)
        {

        }
    }
}
