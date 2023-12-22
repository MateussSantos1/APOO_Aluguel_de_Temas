using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using exercicio_cap4.Models;

namespace exercicio_cap4.DAL
{
    public class TemaDAL
    {
        private EFContext context;

        public TemaDAL()
        {
            this.context = new EFContext();
        }

        public List<Tema> TodososTemas()
        {
            return context.Temas.OrderBy(c => c.Nome).ToList();
        }

        public Tema TemasporID(long? id)
        {
            return context.Temas.Find(id);
        }

        public void AdicionarTema(Tema tema)
        {
            context.Temas.Add(tema);
            context.SaveChanges();
        }

        public void AtualizarTema(Tema tema)
        {
            context.Entry(tema).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletarTema(long? id)
        {
            Tema tema = context.Temas.Find(id);
            context.Temas.Remove(tema);
            context.SaveChanges();
        }
    }
}
