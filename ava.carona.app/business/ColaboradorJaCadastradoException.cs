using System;

namespace ava.carona.app.business
{
    public  class ColaboradorJaCadastradoException : Exception
    {
        public ColaboradorJaCadastradoException()
        {
        }

        public ColaboradorJaCadastradoException(string message) : base(message)
        {
        }

        public ColaboradorJaCadastradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}