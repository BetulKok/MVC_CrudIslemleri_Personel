using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CrudIslemleri_Personel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CrudIslemleri_Personel.Controllers
{
    public class CalisanlarController : Controller
    {
        private readonly UygulamaDbContext _db;

        public CalisanlarController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View(_db.Calisanlar.Include(x => x.Departman).ToList());
        }

        public IActionResult Yeni()
        {
            DepartmanlariYukle();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Yeni(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _db.Calisanlar.Add(calisan);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            DepartmanlariYukle();
            return View();
        }

        void DepartmanlariYukle()
        {
            ViewData["Departmanlar"] = _db.Departmanlar.Select(x => new SelectListItem()
            {
                Text = x.Ad,
                Value = x.Id.ToString()
            }).ToList();
        }

        public IActionResult Sil(int id)
        {
            Calisan calisan = _db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult SilOnay(int id)
        {
            var calisan = _db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            _db.Calisanlar.Remove(calisan);
            _db.SaveChanges();
            TempData["mesaj"] = $"{calisan.TamAd} adlı kişi başarıyla silinmiştir";
            return RedirectToAction("Index" );
        }
        public IActionResult duzenle(int id)
        {
            Calisan calisan = _db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }
            DepartmanlariYukle();
            return View(calisan);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult duzenle(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                //_db.Entry(calisan).State = EntityState.Modified;
                _db.Update(calisan);
                _db.SaveChanges();
                TempData["mesaj"] = $"{calisan.TamAd} adlı kişi başarıyla güncellenmiştir";
                return RedirectToAction("Index");

            }
            DepartmanlariYukle();
            return View();
        }

    }
}
