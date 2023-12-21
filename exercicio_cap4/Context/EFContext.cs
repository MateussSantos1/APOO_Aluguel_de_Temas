using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace exercicio_cap4.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<ItemTema> ItemTemas { get; set; }




        //HABILITAR A EXCLUSAO EM CASCATA DO TEMA E ITEM TEMA
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTema>()
                .HasRequired(i => i.Tema)
                .WithMany(t => t.ItemTemas)
                .HasForeignKey(i => i.TemaId)
                .WillCascadeOnDelete(true);
        }

    }

}