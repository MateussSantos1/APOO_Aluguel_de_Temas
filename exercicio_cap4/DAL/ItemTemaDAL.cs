using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using exercicio_cap4.Models;

namespace exercicio_cap4.DAL
{
    public class ItemTemaDAL
    {
        private EFContext context;

        public ItemTemaDAL()
        {
            this.context = new EFContext();
        }

        public List<ItemTema> TodosOsItensTemas()
        {
            return context.ItemTemas.Include(i => i.Tema).OrderBy(c => c.Nome).ToList();
        }

        public ItemTema ItemTemaPorID(long? id)
        {
            return context.ItemTemas.Include(i => i.Tema).FirstOrDefault(i => i.ItemTemaId == id);
        }

        public void AdicionarItemTema(ItemTema itemTema)
        {
            context.ItemTemas.Add(itemTema);
            context.SaveChanges();
        }

        public void AtualizarItemTema(ItemTema itemTema)
        {
            context.Entry(itemTema).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletarItemTema(long? id)
        {
            ItemTema itemTema = context.ItemTemas.Find(id);
            context.ItemTemas.Remove(itemTema);
            context.SaveChanges();
        }
    }
}
