using Microsoft.EntityFrameworkCore;

namespace GestionCitasMedicas.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<CitaMedica> CitasMedicas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string DatosContacto { get; set; }
        public string HistorialMedico { get; set; }
    }

    public class CitaMedica
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Especialista { get; set; }
        public string Motivo { get; set; }

        public Paciente Paciente { get; set; }
    }

    public class Tratamiento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string Descripcion { get; set; }
        public string Instrucciones { get; set; }
        public string EfectosSecundarios { get; set; }

        public Paciente Paciente { get; set; }
    }
}
