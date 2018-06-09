using System;
using System.Collections.Generic;
using System.Linq;
using ava.carona.app.helpers;

namespace ava.carona.app.domains
{
    public enum StatusCarona
    {
        PENDENTE,
        PERMITIDO,
        NEGADO
    }
    public class Carona : AEntidadeBloqueavel
    {
        private const string MSG_OFERTANTE_NAO_INFORMADO = "Ofertante da carona não informado.";
        private const int LIMITE_MAXIMO_DE_VAGAS = 6;
        private const int LIMITE_MINIMO_DE_VAGAS = 1;
        private Colaborador _ofertante;
        private int _vagas;
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();


        public int VagasTotal
        {
            get
            {
                return _vagas;
            }

            set
            {
                if (value > LIMITE_MAXIMO_DE_VAGAS)
                {
                    throw new QuantidadeTotalDeVagasNaoPermitidoException($"A quantidade máxima de vagas é {LIMITE_MAXIMO_DE_VAGAS}");
                }
                if (value < LIMITE_MINIMO_DE_VAGAS)
                {
                    throw new QuantidadeTotalDeVagasNaoPermitidoException($"A quantidade mínima de vagas é {LIMITE_MINIMO_DE_VAGAS}");
                }

                _vagas = value;
            }
        }
        public int VagasDisponiveis
        {
            get
            {
                return VagasTotal - VagasOcupadas;
            }
        }
        public int VagasOcupadas
        {
            get
            {
                return Caroneiros.Where(cc => cc.StatusCarona == StatusCarona.PERMITIDO).Count(); 
            }
        }

        public Colaborador Ofertante
        {
            get
            {
                return _ofertante;
            }
            set
            {
                value.ValidarArgumentoNulo(MSG_OFERTANTE_NAO_INFORMADO);

                if (value.EstaBloqueado())
                {
                    throw new ColaboradorBloqueadoException("Colaborador sem permissão para oferecer carona.");
                }

                _ofertante = value;
            }
        }

        private void verificarOfertante()
        {
            _ofertante.ValidarArgumentoNulo(MSG_OFERTANTE_NAO_INFORMADO);
        }
        public bool ExisteCaroneiro(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro) != null;
        }

        public StatusCarona PermitirCarona(Colaborador caroneiro)
        {
            if (VagasDisponiveis == 0)
            {
                throw new NaoHaVagasDisponiveisException();
            }
            return AlterarStatusCarona(caroneiro, StatusCarona.PERMITIDO);
        }

        public StatusCarona NegarCarona(Colaborador caroneiro)
        {
            return AlterarStatusCarona(caroneiro, StatusCarona.NEGADO);
        }
        private StatusCarona AlterarStatusCarona(Colaborador caroneiro, StatusCarona status)
        {
            verificarOfertante();

            caroneiro.ValidarArgumentoNulo();

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
            verificarOfertante();

            caroneiro.ValidarArgumentoNulo();
            return Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).FirstOrDefault();
        }


        public void SolicitarCarona(Colaborador caroneiro)
        {
            verificarOfertante();
            caroneiro.ValidarArgumentoNulo();
            if (EstaBloqueado())
            {
                throw new CaronaBloqueadaException();
            }
            if (caroneiro.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException("Colaborador sem permissão para solicitar carona.");
            }

            if (caroneiro.Equals(_ofertante))
            {
                throw new OfertanteComoCaroneiroException("Não é permitido o próprio ofertante ocupar vaga na própria carona.");
            }

            if (ExisteCaroneiro(caroneiro))
            {
                throw new CaroneiroJaInclusoNaCaronaException();
            }



            Caroneiros.Add(new CaronaCaroneiro(this, caroneiro));
        }

      

        public Carona(): base()
        {
        }

        public Carona(Colaborador ofertante, int vagas): this()
        {
            ofertante.ValidarArgumentoNulo(MSG_OFERTANTE_NAO_INFORMADO);
            _ofertante = ofertante;
            VagasTotal = vagas;
        }

        public bool Equals(Carona obj)
        {
            obj.ValidarArgumentoNulo();

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
