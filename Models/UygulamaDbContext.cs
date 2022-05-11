using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CrudIslemleri_Personel.Models
{
    public class UygulamaDbContext: DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options): base(options)
        {

        }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departman>().HasData(
                new Departman() { Id=1 , Ad="Muhasabe"},
                new Departman() { Id=2 , Ad="Bilgi İşlem"},
                new Departman() { Id=3 , Ad="Pazarlama"},
                new Departman() { Id=4 , Ad="İnsan Kaynakları"},
                new Departman() { Id=5 , Ad="Planlama ve Yönetim"},
                new Departman() { Id=6 , Ad="Lojistik"},
                new Departman() { Id=7 , Ad="İdari"}
                );
        }
    }
}
