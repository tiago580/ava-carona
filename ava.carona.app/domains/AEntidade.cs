using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ava.carona.app.domains
{
    public abstract class AEntidade
    {
        public abstract void Validar();
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public AEntidade()
        {
            CreatedAt = DateTime.Now;
        }


    }
}
