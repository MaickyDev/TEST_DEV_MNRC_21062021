using UI.API;
using System.Web.Mvc;
using UI.Models.PersonaFisica;

namespace UI.Controllers
{
    [Authorize]
    public class PersonaFisicaController : Controller
    {
        public APIPersonaFisica adminPersonaFisica = new APIPersonaFisica();


        // GET: PersonaFisica
        public ActionResult Index()
        {
            var process = adminPersonaFisica.get();
            return View(process.Entidad);
        }

        // GET: PersonaFisica/Details/5
        public ActionResult Details(int id = 0)
        {
            if(id == 0)
                return RedirectToAction("Index");
            var item = adminPersonaFisica.getById(id);
            if(item.Codigo == -5000)
                return RedirectToAction("Index");
            return View(item.Entidad);
        }

        // GET: PersonaFisica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaFisica/Create
        [HttpPost]
        public ActionResult Create(PersonaFisica model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View(model);

                var process = adminPersonaFisica.add(model);
                if (process.Codigo != -5000)
                    return RedirectToAction("Index");

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaFisica/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if( id == 0)
                return RedirectToAction("Index");

            var item = adminPersonaFisica.getById(id);
            if (item.Codigo == -5000)
                return RedirectToAction("Index");

            return View(item.Entidad);
        }

        // POST: PersonaFisica/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonaFisica model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var process = adminPersonaFisica.edit(model);
                if (process.Codigo != -5000)
                    return RedirectToAction("Index");
                
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaFisica/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var item = adminPersonaFisica.getById(id);
            if (item.Codigo == -5000)
                return RedirectToAction("Index");

            return View(item.Entidad);
        }

        // POST: PersonaFisica/Delete/5
        [HttpPost]
        public ActionResult Delete(PersonaFisica model)
        {
            try
            {
                // TODO: Add delete logic here
                var process = adminPersonaFisica.delete(model.IdPersonaFisica);
                if (process.Codigo != -5000)
                    return RedirectToAction("Index");

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
