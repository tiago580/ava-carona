using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ava.carona.app.domains
{
    public enum TipoEndereco
    {
        ORIGEM, DESTINO
    }
    public class Endereco: AEntidade
    {
        public TipoEndereco Tipo { get; set; }
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [ForeignKey("Carona")]
        public int CaronaId { get; set; }
        public Carona Carona { get; set; }

        public override void Validar()
        {
            Carona.Validar();
        }
    }
}
