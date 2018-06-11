using System;

namespace ava.carona.app.domains
{
    public class ListaDeEnderecoInvalidaException : Exception
    {
        public override string Message => "Apenas um endereço de origem e um de destino são permitidos.";
        public ListaDeEnderecoInvalidaException()
        {
        }

        public ListaDeEnderecoInvalidaException(string message) : base(message)
        {
        }

        public ListaDeEnderecoInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}