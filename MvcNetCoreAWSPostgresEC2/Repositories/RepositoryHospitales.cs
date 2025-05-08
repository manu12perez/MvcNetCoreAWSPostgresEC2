using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;

        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;

            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = await this.FindDepartamentoAsync(id);
            if (dept != null)
            {
                dept.Nombre = nombre;
                dept.Localidad = localidad;
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento dept = await this.FindDepartamentoAsync(id);
            if (dept != null)
            {
                this.context.Departamentos.Remove(dept);
                await this.context.SaveChangesAsync();
            }
        }

    }
}
