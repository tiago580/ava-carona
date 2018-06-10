using ava.carona.app.helpers;
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
                _EID.ValidarEIDNaoInformado();
                return _EID;
            }
            set
            {
                value.ValidarEIDNaoInformado();

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

        public Colaborador(): base()
        {

        }
        public Colaborador(string EID): this()
        {
            this.EID = EID;
        }

        public override bool Equals(object obj)
        {
            obj.ValidarArgumentoNulo();

            if (!(obj is Colaborador))
            {
                throw new TiposDiferentesException();
            }

            var _obj = obj as Colaborador;
            if (this.EID == _obj.EID)
            {
                return true;
            }
            if (this.Id == _obj.Id && (this.Id > 0 && _obj.Id > 0))
            {
                return true;
            }
            if (this.PID == _obj.PID && (this.PID > 0 && _obj.PID > 0))
            {
                return true;
            }

            return false;

        }

        public override int GetHashCode()
        {
            var hashCode = 2044715075;
            hashCode = hashCode * -1521134295 + PID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_EID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EID);
            return hashCode;
        }
    }
}
