using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Adicione esta linha

namespace exercicio_cap4.Models
{
    public class ItemTema
    {
        [Key] // Adicione esta anotação
        public long? ItemTemaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long? TemaId { get; set; }
        public Tema Tema { get; set; }
    }
}
