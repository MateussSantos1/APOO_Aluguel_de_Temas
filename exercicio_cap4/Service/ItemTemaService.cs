using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using exercicio_cap4.DAL;
using exercicio_cap4.Models;
namespace exercicio_cap4.Services
{

    public class ItemTemaService 
    {
        private ItemTemaDAL itemTemaDAL = new ItemTemaDAL();

        public ItemTemaService()
        {
            this.itemTemaDAL = new ItemTemaDAL();
        }

        public List<ItemTema> TodosOsItensTemas()
        {
            return itemTemaDAL.TodosOsItensTemas();
        }

        public ItemTema ItemTemaPorID(long? id)
        {
            return itemTemaDAL.ItemTemaPorID(id);
        }

        public void AdicionarItemTema(ItemTema item)
        {
            itemTemaDAL.AdicionarItemTema(item);
        }

        public void AtualizarItemTema(ItemTema item)
        {
            itemTemaDAL.AtualizarItemTema(item);
        }

        public void DeletarItemTema(long? id)
        {
            itemTemaDAL.DeletarItemTema(id);
        }
    }
}
