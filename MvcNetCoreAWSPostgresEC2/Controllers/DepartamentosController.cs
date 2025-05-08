using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgresEC2.Models;
using MvcNetCoreAWSPostgresEC2.Repositories;

namespace MvcNetCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospitales repo;

        public DepartamentosController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(id);
            return View(departamento);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.repo.UpdateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return RedirectToAction("Index");
        }

    }
}
