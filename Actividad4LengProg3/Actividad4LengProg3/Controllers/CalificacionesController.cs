using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Actividad4LengProg3.Models;



namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly BdActividad4Context _context;

        public CalificacionesController (BdActividad4Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar (CalificacionViewModel calificacion)
        {
            if (!ModelState.IsValid) 
            {
                var entidad = new CalificacionViewModel
                {
                    MATRICULA_ESTUDIANTE = calificacion.MATRICULA_ESTUDIANTE,
                    CODIGO_MATERIA = calificacion.CODIGO_MATERIA,
                    NOTA = calificacion.NOTA,
                    PERIODO = calificacion.PERIODO
                };

                _context.Calificaciones.Add(entidad);
                _context.SaveChanges();

                var errores = new List<string>();
                foreach (var modelError in ModelState)
                {
                    var key =  modelError.Key;
                    var errors = modelError.Value.Errors;
                    foreach (var error in errors)
                    {
                        errores.Add($"Campo '{key}': {error.ErrorMessage}");
                    }
                }

                TempData["Errores"] = string.Join("|", errores);
                TempData["Mensaje"] = "Error, verifique los campos.";
                return View("Index", calificacion);

            }
            try
            {
                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificación registrada exitosamente.";
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                var error = ex.InnerException?.Message ?? ex.Message;
                TempData["Mensaje"] = $"Error al guardar: {error}";
                return View("Index", calificacion);
            }


            var original = _context.Calificaciones.FirstOrDefault(c => c.ID == calificacion.ID);


        }

        public IActionResult Lista ()
        {
            var calificaciones = _context.Calificaciones.ToList();
            return View(calificaciones);
        }

        [HttpGet]
        public IActionResult Editar (int id)
        { 
            var calificacion = _context.Calificaciones.FirstOrDefault(c  => c.ID == id);
            if (calificacion == null)
            {
                TempData["Mensaje"] = "Materia Inexistente";
                return RedirectToAction("Lista");
            }

            return View(calificacion);
        }

        [HttpPost]
        public IActionResult Editar(CalificacionViewModel calificacion)
        {
            if (ModelState.IsValid)
            {
                var original = _context.Calificaciones.FirstOrDefault(c => c.ID == calificacion.ID);

                if (original == null)
                {
                    TempData["Mensaje"] = "No existe la calificación indicado";
                    return RedirectToAction("Lista");
                }

                
                original.MATRICULA_ESTUDIANTE = calificacion.MATRICULA_ESTUDIANTE;
                original.CODIGO_MATERIA = calificacion.CODIGO_MATERIA;
                original.NOTA = calificacion.NOTA;
                original.PERIODO = calificacion.PERIODO;

                _context.Update(original);
                _context.SaveChanges();

                TempData["Mensaje"] = "Actualizacion Exitosa";
                return RedirectToAction("Lista");
            }

            return View(calificacion);
        }

        public IActionResult Eliminar (int ID)
        {
            var calificacion = _context.Calificaciones.FirstOrDefault(c => c.ID == ID);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificación eliminada satisfactoriamente.";
            }
            else
            {
                TempData["Mensaje"] = "Calificación no encontrada.";
            }

            return RedirectToAction("Lista");
        }
    }
}




//Emely Ferreras Acosta
//SD-2023-04969