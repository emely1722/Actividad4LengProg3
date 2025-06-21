using Actividad3LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
namespace Actividad3LengProg3.Controllers

{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

        public IActionResult Index()
        {
            return View(new EstudianteViewModel());
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel model)

        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(model);
                TempData["Mensaje"] = "Estudiante registrado satisfactoriamente.";
                return RedirectToAction("Lista");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.matricula_estudiante.Equals(model.matricula_estudiante));


                if (estudianteActual == null)
                {
                    TempData["MensajeError"] = "Estudiante no existe";
                    return RedirectToAction("Lista");
                }

                if (estudianteActual != null)
                {
                    estudianteActual.matricula_estudiante = model.matricula_estudiante;
                    estudianteActual.nombre_estudiante = model.nombre_estudiante;
                    estudianteActual.carrera_estudiante = model.carrera_estudiante;
                    estudianteActual.correo_estudiante = model.correo_estudiante;
                    estudianteActual.telefono_estudiante = model.telefono_estudiante;
                    estudianteActual.fecha_nacimiento = model.fecha_nacimiento;
                    estudianteActual.genero_estudiante = model.genero_estudiante;
                    estudianteActual.turno = model.turno.ToString();
                    estudianteActual.tipo_ingreso = model.tipo_ingreso;
                    estudianteActual.becado = model.becado;
                    estudianteActual.porcentaje_beca = model.porcentaje_beca;

                    TempData["Mensaje"] = "Datos editados correctamente";
                    return RedirectToAction("Lista");

                }
            }

            return View(model);
        }


        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.matricula_estudiante == matricula);
            if (estudiante != null) estudiantes.Remove(estudiante);
            TempData["MensajeError"] = "Estudiante eliminado.";
            return RedirectToAction("Lista");
        }


        [HttpGet]
        public IActionResult Lista()

        {
            return View(estudiantes);
        }


        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
            {
                TempData["MensajeError"] = "Matricula no existe.";
                return RedirectToAction("Lista");
            }

            EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.matricula_estudiante.Equals(matricula));

            if (estudianteActual == null)
            {
                TempData["MensajeError"] = "Estudiante no existe.";
                return RedirectToAction("Lista");
            }

            return View(estudianteActual);
        }
    }
}