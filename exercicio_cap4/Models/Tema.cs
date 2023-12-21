using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercicio_cap4.Models
{
    public class Tema
    {

        public long TemaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ItemTema> ItemTemas{ get; set; }

    }
}