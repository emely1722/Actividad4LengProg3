using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
       private readonly BdActividad4Context _context;
       public MateriasController(BdActividad4Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Registrar(MateriaViewModel materia)
        {
                if (ModelState.IsValid)
            {
                _context.Materias.Add(materia); 
                _context.SaveChanges();
                TempData["Mensaje"] = "Materia registrada con éxito";
                return RedirectToAction("Lista");   
            }
                return View(materia);
        }

        public IActionResult Lista()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        public IActionResult Editar(string cod)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.codigo == cod);
            if (materia == null)
            {
                TempData["Mensaje"] = "Materia Inexistente";
                return RedirectToAction("Lista");
            }

            return View(materia);
        }

        public IActionResult Editar(MateriaViewModel materia) 
        {
            
            if (ModelState.IsValid)
            {
                var original = _context.Materias.FirstOrDefault(m => m.codigo == materia.codigo);

                if (original == null) 
                {
                    TempData["Mensaje"] = "Materia inexistente";
                    return RedirectToAction("Lista");
                }

                original.codigo = materia.codigo;
                original.nombre_materia = materia.nombre_materia;
                original.creditos = materia.creditos;
                original.carrera = materia.carrera;

                _context.Update(original);
                _context.SaveChanges();

                TempData["Mensaje"] = "Actualización exitosa";
                return RedirectToAction("Lista");
            }

            return View(materia);
        }


        public IActionResult Eliminar (string cod)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.codigo == cod);
            if (materia == null)
            {
                TempData["Mensaje"] = "Materia Inexistente";
                return RedirectToAction("Lista");
            }

            return View(materia);
        }

    }
}
