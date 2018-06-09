using System;

namespace ava.carona.app.domains
{
    public class Colaborador: AEntidadeBloqueavel
    {
        const int LIMITE_MINIMO_CARACTERES_EID = 3;
        const int LIMITE_MAXIMO_CARACTERES_EID = 20;
        public int PID { get; set; }

        private string _EID;
        public string EID {
            get
            {
                return _EID;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("EID não informado.");
                }

                if (value.Length < LIMITE_MINIMO_CARACTERES_EID)
                {
                    throw new ColaboradorLimiteMinimoDeCaracteresNaoAtingidoException();
                }

                if (value.Length > LIMITE_MAXIMO_CARACTERES_EID)
                {
                    throw new ColaboradorLimiteMaximoDeCaracteresExcedidoException();
                }

                _EID = value; 
            }
        }
        public string Nome { get; set; }

        public Colaborador()
        {

        }
        public Colaborador(string EID)
        {
            this.EID = EID;
        }
    }
}
