using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sklep_internetowy.Models;

namespace Sklep_internetowy.Controllers
{
    public class SklepController : Controller
    {

        public static IList<Produkt> products = new List<Produkt>
        {
            new Produkt(){Id=1, Nazwa="Płyta główna", Opis= "MSI B660M", Ocena=4},
            new Produkt(){Id=2, Nazwa="Pamięć ram", Opis= "8GB DDR4", Ocena=5},
            new Produkt(){Id=3, Nazwa="Procesor", Opis= "Intel I5 9400k", Ocena=3}
        };
        // GET: SklepController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: SklepController/Details/5
        public ActionResult Details(int id)
        {
            return View(products.FirstOrDefault(x=>x.Id==id));
        }

        // GET: SklepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SklepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produkt produkt)
        {
            produkt.Id = products.Count + 1;
            products.Add(produkt);
            return RedirectToAction("Index");
        }

        // GET: SklepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(products.FirstOrDefault(x=>x.Id==id));
        }

        // POST: SklepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produkt produkt)
        {
            Produkt produkt1 = products.FirstOrDefault(x => x.Id == id);
            produkt1.Nazwa = produkt.Nazwa;
            produkt1.Opis = produkt.Opis;
            produkt1.Ocena = produkt.Ocena;
            return RedirectToAction("Index");
        }

        // GET: SklepController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(products.FirstOrDefault(x => x.Id == id));
        }

        // POST: SklepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produkt produkt)
        {
            Produkt produkt1 = products.FirstOrDefault(x => x.Id == id);
            products.Remove(produkt1);
            return RedirectToAction("Index");
        }

        public ActionResult Buy(int id)
        {
            return View(products.FirstOrDefault(x => x.Id == id));
        }
    }
}
