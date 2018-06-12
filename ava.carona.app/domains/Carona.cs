using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private const string MSG_ENDERECO_ORIGEM_NAO_INFORMADO = "Endereço de origem não informado.";
        private const string MSG_ENDERECO_DESTINO_NAO_INFORMADO = "Endereço de destino não informado.";
        private const int LIMITE_MAXIMO_DE_VAGAS = 6;
        private const int LIMITE_MINIMO_DE_VAGAS = 1;

        public IList<CaronaCaroneiro> Caronas { get; set; } = new List<CaronaCaroneiro>();

        public DateTime Horario { get; set; }
        private int _vagas;

        public IList<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();

        [MaxLength(LIMITE_MAXIMO_DE_VAGAS, ErrorMessageResourceType = typeof(ColaboradorLimiteMaximoDeCaracteresExcedidoException))]
        [MinLength(LIMITE_MINIMO_DE_VAGAS, ErrorMessageResourceType = typeof(ColaboradorLimiteMinimoDeCaracteresNaoAtingidoException))]
        public int VagasTotal
        {
            get
            {
                return _vagas;
            }

            set
            {
                value.ValidarVagas(LIMITE_MAXIMO_DE_VAGAS, LIMITE_MINIMO_DE_VAGAS);
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

        //[Required]
        public Colaborador Ofertante { get; set; }

        public void ValidarOfertante(Colaborador ofertante = null)
        {
            const string Msg = "Colaborador sem permissão para oferecer carona.";

            ofertante = (ofertante != null) ? ofertante : Ofertante;
            ofertante.ValidarArgumentoNulo(MSG_OFERTANTE_NAO_INFORMADO);
            
            if (ofertante.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException(Msg);
            }
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
            ValidarOfertante();

            caroneiro.ValidarArgumentoNulo();

            if (!ExisteCaroneiro(caroneiro))
            {
                throw new CaroneiroNaoEncontradoException();
            }

            caroneiro.Validar();

            Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).Select(cc => cc.StatusCarona = status).ToList();
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }


        public StatusCarona ObterStatusCarona(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }
        public CaronaCaroneiro ObterPorCaroneiro(Colaborador caroneiro)
        {
            ValidarOfertante();

            caroneiro.ValidarArgumentoNulo();
            return Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).FirstOrDefault();
        }

        public void ValidarVagasDisponiveis()
        {
            if (VagasOcupadas == VagasTotal)
            {
                throw new NaoHaVagasDisponiveisException();
            }
        }

        public void SolicitarCarona(Colaborador caroneiro)
        {
            ValidarOfertante();
            ValidarVagasDisponiveis();
            caroneiro.ValidarArgumentoNulo();

            if (EstaBloqueado())
            {
                throw new CaronaBloqueadaException();
            }
            if (caroneiro.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException("Colaborador sem permissão para solicitar carona.");
            }

            if (caroneiro.Equals(Ofertante))
            {
                throw new OfertanteComoCaroneiroException("Não é permitido o próprio ofertante ocupar vaga na própria carona.");
            }

            if (ExisteCaroneiro(caroneiro))
            {
                throw new CaroneiroJaInclusoNaCaronaException();
            }
            caroneiro.Validar();

            Caroneiros.Add(new CaronaCaroneiro(this, caroneiro));
        }

      

        public Carona(): base()
        {
            Horario = DateTime.Now;
        }

        public Carona(Colaborador ofertante, int vagas, Endereco origem, Endereco destino): this()
        {
            ofertante.ValidarArgumentoNulo();
            vagas.ValidarVagas(LIMITE_MAXIMO_DE_VAGAS, LIMITE_MINIMO_DE_VAGAS);

            origem.ValidarArgumentoNulo();
            destino.ValidarArgumentoNulo();
            
            Ofertante = ofertante;
            VagasTotal = vagas;

            origem.Tipo = TipoEndereco.ORIGEM;
            destino.Tipo = TipoEndereco.DESTINO;

            Enderecos.Add(origem);
            Enderecos.Add(destino);
            //Origem.CaronaOrigem = this;
            //Destino.CaronaDestino = this;
        }

        public Endereco ObterEndereco(TipoEndereco tipo)
        {
            return Enderecos.Where(e => e.Tipo == tipo).FirstOrDefault();
        }
        public override bool Equals(object obj)
        {
            obj.ValidarArgumentoNulo();

            if (!(obj is Carona))
            {
                return false;
            }



            var _obj = obj as Carona;

            _obj.Horario.ValidarArgumentoNulo();

            if (this.Id == _obj.Id)
            {
                return true;
            }

            if (this.Horario.Date == _obj.Horario.Date && 
                this.Horario.Hour == _obj.Horario.Hour &&
                this.Horario.Minute == _obj.Horario.Minute)
            {
                return true;
            }
            return false;

        }

        public override int GetHashCode()
        {
            var hashCode = -1320143218;
            hashCode = hashCode * -1521134295 + Horario.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Colaborador>.Default.GetHashCode(Ofertante);
            return hashCode;
        }

        public void ValidarEnderecos()
        {
            Enderecos.ValidarArgumentoNulo();
            if (
                Enderecos.Count != 2 ||
                Enderecos.Where(e => e.Tipo == TipoEndereco.DESTINO).Count() != 1
                )
            {
                throw new ListaDeEnderecoInvalidaException();
            }

        }
        public override void Validar()
        {
            this.ValidarBloqueio();
            _vagas.ValidarVagas(LIMITE_MAXIMO_DE_VAGAS, LIMITE_MINIMO_DE_VAGAS);
            ValidarEnderecos();
            ValidarOfertante();
        }
    }
}
