using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ava.carona.app.domains
{
    public enum StatusCarona
    {
        PENDENTE,
        PERMITIDO,
        NEGADO
    }
    public class Carona : AEntidade
    {
        private Colaborador _ofertante;
        public Colaborador Ofertante
        {
            get
            {
                return _ofertante;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ofertante da carona não informado.");
                }

                if (value.EstaBloqueado())
                {
                    throw new ColaboradorBloqueadoException("Colaborador sem permissão para oferecer carona.");
                }

                _ofertante = value;
            }
        }
        public int VagasTotal { get; set; }
        public int VagasDisponiveis { get; set; }
        public int VagasOcupadas { get; set; }
        public bool ExisteCaroneiro(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro) != null;
        }

        public StatusCarona PermitirCarona(Colaborador caroneiro)
        {
            AlterarStatusCarona(caroneiro, StatusCarona.PERMITIDO);
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }

        public StatusCarona NegarCarona(Colaborador caroneiro)
        {
            AlterarStatusCarona(caroneiro, StatusCarona.NEGADO);
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }
        private StatusCarona AlterarStatusCarona(Colaborador caroneiro, StatusCarona status)
        {
            VerificarArgumentoNulo(caroneiro);

            if (!ExisteCaroneiro(caroneiro))
            {
                throw new CaroneiroNaoEncontradoException();
            }

            Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).Select(cc => cc.StatusCarona = status).ToList();
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }


        public StatusCarona ObterStatusCarona(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }
        public CaronaCaroneiro ObterPorCaroneiro(Colaborador caroneiro)
        {
            VerificarArgumentoNulo(caroneiro);
            return Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).FirstOrDefault();
        }


        public void SolicitarCarona(Colaborador caroneiro)
        {
            VerificarArgumentoNulo(caroneiro);
            if (caroneiro.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException("Colaborador sem permissão para solicitar carona.");
            }

            Caroneiros.Add(new CaronaCaroneiro(this, caroneiro));
        }

      
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();

        public Carona()
        {
        }

        public bool Equals(Carona obj)
        {
            VerificarArgumentoNulo(obj);

            if (!(obj is Carona))
            {
                throw new TiposDiferentesException();
            }

            var _obj = obj as Carona;
            if (this.Id == _obj.Id)
            {
                return true;
            }

            return false;

        }

    }
}
