using ava.carona.app.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ava.carona.app.domains
{
    public class Colaborador: AEntidadeBloqueavel
    {
        const int LIMITE_MINIMO_CARACTERES_EID = 3;
        const int LIMITE_MAXIMO_CARACTERES_EID = 20;
        private const string MSG_EID_NAO_INFORMADO = "EID não informado.";
        //public IList<CaronaCaroneiro> Caronas { get; set; } = new List<CaronaCaroneiro>();
        public int PID { get; set; }

        [Required]
        [MinLength(LIMITE_MINIMO_CARACTERES_EID)]
        [MaxLength(LIMITE_MAXIMO_CARACTERES_EID)]
        public string EID { get; set; }
        public string Nome { get; set; }

        public Colaborador(): base()
        {

        }
        public Colaborador(string EID): this()
        {
            EID.ValidarEID();
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EID);
            return hashCode;
        }

        public override void Validar()
        {
            this.ValidarBloqueio();
            EID.ValidarEID();
        }
    }
}
