using System;
using System.Collections.Generic;

namespace ava.carona.app.domains
{
    public class Colaborador: AEntidadeBloqueavel
    {
        const int LIMITE_MINIMO_CARACTERES_EID = 3;
        const int LIMITE_MAXIMO_CARACTERES_EID = 20;
        private const string MSG_EID_NAO_INFORMADO = "EID não informado.";

        public int PID { get; set; }

        private string _EID;
        public string EID {
            get
            {
                VerificarArgumentoNulo(_EID, MSG_EID_NAO_INFORMADO);
                return _EID;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(MSG_EID_NAO_INFORMADO);
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

        public bool Equals(Colaborador obj)
        {
            VerificarArgumentoNulo(obj);

            if (!(obj is Colaborador))
            {
                throw new TiposDiferentesException();
            }

            var _obj = obj as Colaborador;
            if (this.EID == _obj.EID)
            {
                return true;
            }
            if (this.Id == _obj.Id && (this.Id > 0 || obj.Id > 0))
            {
                return true;
            }
            if (this.PID == _obj.PID && (this.PID > 0 || obj.PID > 0))
            {
                return true;
            }

            return false;

        }


    }
}
