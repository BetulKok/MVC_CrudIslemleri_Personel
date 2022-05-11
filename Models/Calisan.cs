using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CrudIslemleri_Personel.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string TamAd { get; set; }
        public int DepartmanId { get; set; }

        public Departman Departman { get; set; }
    }
}
