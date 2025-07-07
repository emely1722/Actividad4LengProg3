using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly BdActividad4Context _context;

        public EstudiantesController(BdActividad4Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges(); 
                TempData["Mensaje"] = "Estudiante registrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }


        public IActionResult Lista()
        {

            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);

        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.matricula_estudiante == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el usuario indicado";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var original = _context.Estudiantes.FirstOrDefault(e => e.matricula_estudiante == estudiante.matricula_estudiante);

                if (original == null)
                {
                    TempData["Mensaje"] = "No existe el usuario indicado";
                    return RedirectToAction("Lista");
                }

                
                original.nombre_estudiante = estudiante.nombre_estudiante;
                original.carrera_estudiante = estudiante.carrera_estudiante;
                original.correo_estudiante = estudiante.correo_estudiante;
                original.telefono_estudiante = estudiante.telefono_estudiante;
                original.fecha_nacimiento = estudiante.fecha_nacimiento;
                original.genero_estudiante = estudiante.genero_estudiante;
                original.turno = estudiante.turno;
                original.tipo_ingreso = estudiante.tipo_ingreso;
                original.porcentaje_beca = estudiante.porcentaje_beca;
                original.becado = estudiante.becado;
                original.terminos_condiciones = estudiante.terminos_condiciones;

                _context.Update(original); 
                _context.SaveChanges();    

                TempData["Mensaje"] = "Actualizaciones exitosas";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.matricula_estudiante == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el usuario indicado";
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.matricula_estudiante == matricula);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges(); 
                TempData["Mensaje"] = "Estudiante eliminado correctamente";
            }

            return RedirectToAction("Lista");
        }

    }
}