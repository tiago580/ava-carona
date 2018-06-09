using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public abstract class AEntidade
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public AEntidade()
        {
            CreatedAt = DateTime.Now;
        }

        protected void VerificarArgumentoNulo(object entidade, string msg = null)
        {
            if (entidade == null)
            {
                if (msg != null)
                {
                    throw new ArgumentNullException(msg);
                }
                throw new ArgumentNullException();
            }
        }

    }
}
