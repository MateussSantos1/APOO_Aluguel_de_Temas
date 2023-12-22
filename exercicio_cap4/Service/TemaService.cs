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
    public class TemaService
    {
        private TemaDAL temaDAL = new TemaDAL();

        public TemaService()
        {
            this.temaDAL = new TemaDAL();
        }

        public List<Tema> TodososTemas()
        {
            return temaDAL.TodososTemas();
        }

        public Tema TemasporID(long? id)
        {
            return temaDAL.TemasporID(id);
        }

        public void AdicionarTema(Tema tema)
        {
            temaDAL.AdicionarTema(tema);
        }

        public void AtualizarTema(Tema tema)
        {
            temaDAL.AtualizarTema(tema);
        }

        public void DeletarTema(long? id)
        {
            temaDAL.DeletarTema(id);
        }
    }
}
