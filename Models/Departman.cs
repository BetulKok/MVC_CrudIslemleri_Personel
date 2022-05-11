using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CrudIslemleri_Personel.Models
{
    public class Departman
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Ad { get; set; }

        public List<Calisan> Calisanlar { get; set; }
    }
}
